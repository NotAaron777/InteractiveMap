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
/// - El mapa inicia blanco: solo el territorio tocado en su pin se colorea
///   con su máscara PNG y su color.
/// - Cada territorio se etiqueta con su nombre en el centroide de su máscara.
/// - Al tocar un pin se colorea de inmediato su territorio (sin tarjeta
///   emergente ni segunda pulsación); tocar otro pin cambia la selección.
/// </summary>
public class MapaHistoricoView : SKCanvasView
{
    private const byte UmbralAlfa = 64;
    private const float ZoomMin = 1f;
    private const float ZoomMax = 4f;

    // El mapa inicia blanco: solo el territorio tocado se colorea, usando su
    // máscara PNG y su color casi opaco.
    private const float AlfaTerritorioActivo = 0.88f;

    private const float EtiquetaFuenteBase = 12f;

    // Mismo estilo y tamaño de pin que el mapa interactivo.
    private const float PinRadio = 11f;
    private const float PinRadioToque = 22f;

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

    // Pines de los territorios (mismo estilo que el mapa principal).
    private readonly List<SKPoint> _pines = new();

    // Desplazamiento visual solo de la posición del pin (no de la máscara ni de la
    // etiqueta) para separar los dos pines que se superponen en el occidente:
    // Chorotega y Maribio. Está en coordenadas del mapa, por lo que la separación
    // se conserva al cambiar el zoom y al desplazar.
    private static readonly Dictionary<string, SKPoint> AjustePin = new()
    {
        ["chorotega"] = new SKPoint(22f, 9f),
        ["maribio"] = new SKPoint(-22f, -9f),
    };

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
        _pines.Clear();
        foreach (var territorio in _territorios)
        {
            if (!_mascaras.TryGetValue(territorio.Id, out var alfas)) { _pines.Add(default); continue; }

            long sumaX = 0, sumaY = 0, total = 0;

            // Límites del recuadro de la máscara: el pin se coloca en su centro,
            // igual que el mapa interactivo.
            var minX = _mapaW; var minY = _mapaH;
            var maxX = -1; var maxY = -1;

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
                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                        if (y < minY) minY = y;
                        if (y > maxY) maxY = y;
                    }
                }
            }

            territorio.Centroide = total > 0
                ? new SKPoint(sumaX / (float)total, sumaY / (float)total)
                : default;

            var pin = maxX >= minX && maxY >= minY
                ? new SKPoint((minX + maxX) / 2f, (minY + maxY) / 2f)
                : default;

            if (pin != default && AjustePin.TryGetValue(territorio.Id, out var ajuste))
                pin = new SKPoint(pin.X + ajuste.X, pin.Y + ajuste.Y);

            _pines.Add(pin);
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

        // Un toque en un pin colorea de inmediato únicamente su territorio,
        // sin tarjeta "Ver zona" ni segunda pulsación.
        for (var i = 0; i < _pines.Count; i++)
        {
            if (_pines[i] == default || !PosicionPinEnCanvas(i, out var pos)) continue;
            if (!EstaEnPin(punto, pos)) continue;

            _resaltados.Clear();
            _resaltados.Add(_territorios[i].Id);
            InvalidateSurface();
            return;
        }

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
        DibujarPines(canvas);
    }

    private void DibujarTerritorios(SKCanvas canvas, SKRect destino)
    {
        if (_resaltados.Count == 0) return;

        foreach (var territorio in _territorios)
        {
            if (!_resaltados.Contains(territorio.Id) || territorio.Bitmaps.Count == 0) continue;

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
                    0, 0, 0, AlfaTerritorioActivo, 0
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

    private void DibujarPines(SKCanvas canvas)
    {
        for (var i = 0; i < _pines.Count; i++)
        {
            if (_pines[i] == default) continue;
            if (!PosicionPinEnCanvas(i, out var pos)) continue;
            DibujarPin(canvas, pos);
        }
    }

    private static void DibujarPin(SKCanvas canvas, SKPoint pos)
    {
        using var cuerpo = new SKPaint
        {
            IsAntialias = true,
            Shader = SKShader.CreateLinearGradient(
                new SKPoint(0, pos.Y - PinRadio),
                new SKPoint(0, pos.Y + PinRadio),
                new[] { SKColor.Parse("#FF2A85"), SKColor.Parse("#E91E63"), SKColor.Parse("#9D4EDD") },
                new[] { 0f, 0.5f, 1f },
                SKShaderTileMode.Clamp)
        };
        using var halo = new SKPaint
        {
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 3.5f,
            Color = SKColor.Parse("#00F2FE").WithAlpha(140)
        };
        using var brillo = new SKPaint { IsAntialias = true, Color = SKColors.White.WithAlpha(240) };

        canvas.DrawCircle(new SKPoint(pos.X, pos.Y - PinRadio * 0.45f), PinRadio + 2.5f, halo);
        canvas.DrawCircle(new SKPoint(pos.X, pos.Y - PinRadio * 0.55f), PinRadio, cuerpo);
        canvas.DrawCircle(new SKPoint(pos.X, pos.Y + PinRadio * 0.65f), PinRadio * 0.42f, cuerpo);
        canvas.DrawCircle(new SKPoint(pos.X, pos.Y - PinRadio * 0.55f), PinRadio * 0.28f, brillo);
    }

    private bool PosicionPinEnCanvas(int i, out SKPoint p)
    {
        p = default;
        if (_mapa == null || i < 0 || i >= _pines.Count) return false;

        var escalaBase = Math.Min(_canvasW / (float)_mapaW, _canvasH / (float)_mapaH);
        var dibujadoW = _mapaW * escalaBase * _escala;
        var dibujadoH = _mapaH * escalaBase * _escala;
        var origenX = _canvasW / 2f - dibujadoW * _centroX;
        var origenY = _canvasH / 2f - dibujadoH * _centroY;
        var pt = _pines[i];
        p = new SKPoint(origenX + pt.X * dibujadoW / _mapaW, origenY + pt.Y * dibujadoH / _mapaH);
        return true;
    }

    private static bool EstaEnPin(SKPoint punto, SKPoint pin) =>
        Math.Abs(punto.X - pin.X) <= PinRadioToque && Math.Abs(punto.Y - pin.Y) <= PinRadioToque;
}
