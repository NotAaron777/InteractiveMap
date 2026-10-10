using System.Runtime.InteropServices;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace MapaInteractivo.Maui.Controls;

public class TerritorioTocadoEventArgs : EventArgs
{
    public TerritorioTocadoEventArgs(List<TerritorioHit> territorios) => Territorios = territorios;
    public List<TerritorioHit> Territorios { get; }
    public bool Multiple => Territorios.Count > 1;
}

public class TerritorioHit
{
    public string Id { get; set; } = "";
    public string Nombre { get; set; } = "";
    public SKColor Color { get; set; }
}

public class TerritorioHistorico
{
    public string Id { get; set; } = "";
    public string Nombre { get; set; } = "";
    public SKColor Color { get; set; }
    public string[] Archivos { get; set; } = Array.Empty<string>();
    public List<SKBitmap> Bitmaps { get; } = new();
    public SKPoint Centroide { get; set; }
}

/// <summary>
/// Mapa historico de los pueblos originarios de Nicaragua.
///
/// Módulo independiente del mapa interactivo (<see cref="MapaInteractivoView"/>):
/// reutiliza la misma imagen base ("Mapas/mapa_blanco.png", 1184x1080) pero carga
/// las mascaras historicas del autor (dibujadas en Krita, empaquetadas bajo
/// "MascarasHistoricas/"), que comparten dimensiones y alineación exactas con el mapa.
///
/// Diferencias con el mapa interactivo:
/// - Los territorios se muestran siempre con un tinte suave (paleta histórica),
///   no solo al resaltarse.
/// - Cada territorio se etiqueta con su nombre en el centroide de su máscara.
/// - No hay pines ni popup; la selección abre el panel de información de la página.
/// </summary>
public class MapaHistoricoView : SKCanvasView
{
    private const byte UmbralAlfa = 64;
    private const float ZoomMin = 1f;
    private const float ZoomMax = 4f;

    // Tinte permanente para que los colores de los territorios sean claramente visibles
    // sobre el mapa base blanco; el seleccionado se dibuja casi opaco y, mientras
    // haya una selección, los demás se atenúan temporalmente (sin alterarlos de forma
    // permanente). Antes eran 0.34/0.80 y los colores quedaban lavados (tonos beige).
    private const float AlfaTerritorio = 0.50f;
    private const float AlfaTerritorioAtenuado = 0.35f;
    private const float AlfaTerritorioActivo = 0.88f;

    private const float EtiquetaFuenteBase = 12f;

    private readonly List<TerritorioHistorico> _territorios = new();
    private SKBitmap? _mapa;
    private int _mapaW, _mapaH;
    private readonly Dictionary<string, List<byte[]>> _mascaras = new();

    private float _escala = 1f;
    private float _centroX = 0.5f;
    private float _centroY = 0.5f;
    private bool _cargando;

    private float _canvasW, _canvasH;

    private readonly HashSet<string> _resaltados = new();

    private SKPoint _ultimoToque;
    private bool _panzando;
    private float _distanciaArrastre;

    public event EventHandler<TerritorioTocadoEventArgs>? TerritorioTocado;

    public MapaHistoricoView()
    {
        EnableTouchEvents = true;
        Touch += OnTouch;
        PaintSurface += OnPaintSurface;
    }

    public void AgregarTerritorio(string id, string nombre, SKColor color, params string[] archivos)
    {
        _territorios.Add(new TerritorioHistorico { Id = id, Nombre = nombre, Color = color, Archivos = archivos });
    }

    public async Task CargarAsync()
    {
        if (_mapa != null && _mascaras.Count > 0) return;
        if (_cargando) return;
        _cargando = true;

        var mapa = await CargarBitmapAsync("Mapas/mapa_blanco.png");
        _mapa = mapa;
        _mapaW = mapa.Width;
        _mapaH = mapa.Height;

        foreach (var territorio in _territorios)
        {
            var alfas = new List<byte[]>();
            foreach (var archivo in territorio.Archivos)
            {
                var mascara = await CargarBitmapAsync($"MascarasHistoricas/{archivo}");
                territorio.Bitmaps.Add(mascara);
                alfas.Add(AplanaAlfa(mascara));
            }
            _mascaras[territorio.Id] = alfas;
        }

        CalcularCentroides();

        _cargando = false;
        InvalidateSurface();
    }

    private void CalcularCentroides()
    {
        foreach (var territorio in _territorios)
        {
            if (!_mascaras.TryGetValue(territorio.Id, out var alfas)) continue;

            long sumaX = 0, sumaY = 0, total = 0;

            foreach (var alfa in alfas)
            {
                for (var y = 0; y < _mapaH; y++)
                {
                    var fila = y * _mapaW;
                    for (var x = 0; x < _mapaW; x++)
                    {
                        if (alfa[fila + x] <= UmbralAlfa) continue;
                        sumaX += x;
                        sumaY += y;
                        total++;
                    }
                }
            }

            territorio.Centroide = total > 0
                ? new SKPoint(sumaX / (float)total, sumaY / (float)total)
                : default;
        }
    }

    public void Acercar() => CambiarZoom(1.25f);
    public void Alejar() => CambiarZoom(1f / 1.25f);

    public void Centrar()
    {
        _escala = ZoomMin;
        _centroX = 0.5f;
        _centroY = 0.5f;
        InvalidateSurface();
    }

    public void LimpiarResaltado()
    {
        if (_resaltados.Count == 0) return;
        _resaltados.Clear();
        InvalidateSurface();
    }

    private void CambiarZoom(float factor)
    {
        _escala = (float)Math.Clamp(_escala * factor, ZoomMin, ZoomMax);
        InvalidateSurface();
    }

    private static async Task<SKBitmap> CargarBitmapAsync(string ruta)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(ruta);
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        ms.Position = 0;
        return SKBitmap.Decode(ms) ?? throw new InvalidDataException($"Imagen no válida: {ruta}");
    }

    private byte[] AplanaAlfa(SKBitmap origen)
    {
        using var escalada = new SKBitmap(_mapaW, _mapaH, SKColorType.Rgba8888, SKAlphaType.Premul);
        using (var canvas = new SKCanvas(escalada))
        {
            canvas.DrawBitmap(origen, new SKRect(0, 0, _mapaW, _mapaH));
        }

        var length = _mapaW * _mapaH * 4;
        var bytes = new byte[length];
        Marshal.Copy(escalada.GetPixels(), bytes, 0, length);
        var alfa = new byte[_mapaW * _mapaH];
        for (var i = 0; i < alfa.Length; i++)
            alfa[i] = bytes[i * 4 + 3];
        return alfa;
    }

    private void OnTouch(object? sender, SKTouchEventArgs e)
    {
        switch (e.ActionType)
        {
            case SKTouchAction.Pressed:
                _ultimoToque = e.Location;
                _distanciaArrastre = 0;
                _panzando = _escala > ZoomMin + 0.01f;
                break;

            case SKTouchAction.Moved:
                if (!_panzando) break;
                var dx = (e.Location.X - _ultimoToque.X);
                var dy = (e.Location.Y - _ultimoToque.Y);
                _distanciaArrastre += Math.Abs(dx) + Math.Abs(dy);
                var destinoX = _centroX - dx / (_canvasW * _escala);
                var destinoY = _centroY - dy / (_canvasH * _escala);
                _centroX = (float)Math.Clamp(destinoX, 0f, 1f);
                _centroY = (float)Math.Clamp(destinoY, 0f, 1f);
                _ultimoToque = e.Location;
                InvalidateSurface();
                break;

            case SKTouchAction.Released:
                if (_distanciaArrastre < 12f)
                    ResolverToque(e.Location);
                break;

            case SKTouchAction.Cancelled:
                _panzando = false;
                break;
        }

        e.Handled = true;
    }

    private void ResolverToque(SKPoint punto)
    {
        if (_mapa == null) return;
        if (!TransformarAPuntoMapa(punto, out var mx, out var my)) return;

        if (mx < 0 || my < 0 || mx >= _mapaW || my >= _mapaH)
        {
            LimpiarResaltado();
            return;
        }

        var idx = (int)my * _mapaW + (int)mx;
        var golpes = new List<TerritorioHit>();
        var vistos = new HashSet<string>();

        foreach (var territorio in _territorios)
        {
            if (vistos.Contains(territorio.Id)) continue;
            if (!_mascaras.TryGetValue(territorio.Id, out var alfas)) continue;
            foreach (var alfa in alfas)
            {
                if (idx < alfa.Length && alfa[idx] > UmbralAlfa)
                {
                    golpes.Add(new TerritorioHit { Id = territorio.Id, Nombre = territorio.Nombre, Color = territorio.Color });
                    vistos.Add(territorio.Id);
                    break;
                }
            }
        }

        if (golpes.Count == 0)
        {
            LimpiarResaltado();
            return;
        }

        _resaltados.Clear();
        foreach (var golpe in golpes)
            _resaltados.Add(golpe.Id);
        InvalidateSurface();

        TerritorioTocado?.Invoke(this, new TerritorioTocadoEventArgs(golpes));
    }

    private bool TransformarAPuntoMapa(SKPoint punto, out int mx, out int my)
    {
        mx = 0; my = 0;
        if (_mapa == null || _canvasW <= 0 || _canvasH <= 0) return false;

        var escalaBase = Math.Min(_canvasW / (float)_mapaW, _canvasH / (float)_mapaH);
        var dibujadoW = _mapaW * escalaBase * _escala;
        var dibujadoH = _mapaH * escalaBase * _escala;
        var origenX = _canvasW / 2f - dibujadoW * _centroX;
        var origenY = _canvasH / 2f - dibujadoH * _centroY;

        mx = (int)((punto.X - origenX) * _mapaW / dibujadoW);
        my = (int)((punto.Y - origenY) * _mapaH / dibujadoH);
        return true;
    }

    private void OnPaintSurface(object? sender, SKPaintSurfaceEventArgs e)
    {
        _canvasW = e.Info.Width;
        _canvasH = e.Info.Height;
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColor.Parse("#030F26"));

        if (_mapa == null) return;

        var escalaBase = Math.Min(_canvasW / (float)_mapaW, _canvasH / (float)_mapaH);
        var dibujadoW = _mapaW * escalaBase * _escala;
        var dibujadoH = _mapaH * escalaBase * _escala;
        var origenX = _canvasW / 2f - dibujadoW * _centroX;
        var origenY = _canvasH / 2f - dibujadoH * _centroY;
        var destino = new SKRect(origenX, origenY, origenX + dibujadoW, origenY + dibujadoH);

        canvas.DrawBitmap(_mapa, destino);

        DibujarTerritorios(canvas, destino);
        DibujarEtiquetas(canvas, destino);
    }

    private void DibujarTerritorios(SKCanvas canvas, SKRect destino)
    {
        foreach (var territorio in _territorios)
        {
            if (territorio.Bitmaps.Count == 0) continue;

            var activo = _resaltados.Contains(territorio.Id);
            float alfa;
            if (activo) alfa = AlfaTerritorioActivo;
            else if (_resaltados.Count > 0) alfa = AlfaTerritorioAtenuado;
            else alfa = AlfaTerritorio;

            var r = territorio.Color.Red / 255f;
            var g = territorio.Color.Green / 255f;
            var b = territorio.Color.Blue / 255f;

            using var paint = new SKPaint
            {
                IsAntialias = true,
                ColorFilter = SKColorFilter.CreateColorMatrix(new[]
                {
                    0f, 0, 0, 0, r,
                    0, 0, 0, 0, g,
                    0, 0, 0, 0, b,
                    0, 0, 0, alfa, 0
                })
            };

            foreach (var bmp in territorio.Bitmaps)
                canvas.DrawBitmap(bmp, destino, paint);
        }
    }

    private void DibujarEtiquetas(SKCanvas canvas, SKRect destino)
    {
        var tamano = EtiquetaFuenteBase * (float)Math.Pow(_escala, 0.35);
        tamano = Math.Clamp(tamano, EtiquetaFuenteBase, EtiquetaFuenteBase * 1.6f);

        using var typeface = SKTypeface.FromFamilyName("OpenSansSemibold");
        using var fuente = new SKFont(typeface, tamano);
        using var halo = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 3f,
            Color = new SKColor(3, 15, 38, 215)
        };
        using var relleno = new SKPaint
        {
            IsAntialias = true,
            Color = SKColors.White.WithAlpha(225)
        };

        foreach (var territorio in _territorios)
        {
            if (territorio.Bitmaps.Count == 0 || territorio.Centroide == default) continue;

            var px = destino.Left + territorio.Centroide.X / _mapaW * destino.Width;
            var py = destino.Top + territorio.Centroide.Y / _mapaH * destino.Height;

            canvas.DrawText(territorio.Nombre, px, py, SKTextAlign.Center, fuente, halo);
            canvas.DrawText(territorio.Nombre, px, py, SKTextAlign.Center, fuente, relleno);
        }
    }
}
