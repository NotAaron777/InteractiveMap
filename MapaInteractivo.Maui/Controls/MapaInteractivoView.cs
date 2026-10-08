using System.Runtime.InteropServices;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace MapaInteractivo.Maui.Controls;

public class ZonaTocadaEventArgs : EventArgs
{
    public ZonaTocadaEventArgs(List<ZonaHit> zonas) => Zonas = zonas;
    public List<ZonaHit> Zonas { get; }
    public bool Multiple => Zonas.Count > 1;
}

public class ZonaHit
{
    public string Id { get; set; } = "";
    public string Nombre { get; set; } = "";
    public SKColor Color { get; set; }
}

public class Zona
{
    public string Id { get; set; } = "";
    public string Nombre { get; set; } = "";
    public SKColor Color { get; set; }
    public string[] Archivos { get; set; } = Array.Empty<string>();
    public List<SKBitmap> Bitmaps { get; } = new();
}

public class MapaInteractivoView : SKCanvasView
{
    private const byte UmbralAlfa = 64;
    private const float ZoomMin = 1f;
    private const float ZoomMax = 4f;
    private const float PinRadio = 11f;
    private const float PinRadioToque = 22f;
    private const float PopupAncho = 200f;
    private const float PopupAlto = 48f;

    private readonly List<Zona> _zonas = new();
    private SKBitmap? _mapa;
    private int _mapaW, _mapaH;
    private readonly Dictionary<string, List<byte[]>> _masks = new();

    private float _escala = 1f;
    private float _centroX = 0.5f;
    private float _centroY = 0.5f;
    private bool _cargandoMasks;

    private float _canvasW, _canvasH;

    private readonly List<SKPoint> _pines = new();
    private int _pinActivo = -1;

    private readonly List<string> _resaltadas = new();

    private SKPoint _ultimoToque;
    private bool _panzando;
    private float _distanciaArrastre;

    public event EventHandler<ZonaTocadaEventArgs>? ZonaTocada;

    public MapaInteractivoView()
    {
        EnableTouchEvents = true;
        Touch += OnTouch;
        PaintSurface += OnPaintSurface;
    }

    public void AgregarZona(string id, string nombre, SKColor color, params string[] archivos)
    {
        _zonas.Add(new Zona { Id = id, Nombre = nombre, Color = color, Archivos = archivos });
    }

    public async Task CargarAsync()
    {
        if (_mapa != null && _masks.Count > 0) return;
        if (_cargandoMasks) return;
        _cargandoMasks = true;

        var mapa = await CargarBitmapAsync("Mapas/mapa_blanco.png");
        _mapa = mapa;
        _mapaW = mapa.Width;
        _mapaH = mapa.Height;

        foreach (var zona in _zonas)
        {
            var alfas = new List<byte[]>();
            foreach (var archivo in zona.Archivos)
            {
                var mask = await CargarBitmapAsync($"Mascaras/{archivo}");
                zona.Bitmaps.Add(mask);
                alfas.Add(AplanaAlfa(mask));
            }
            _masks[zona.Id] = alfas;
        }

        CalcularCentroides();

        _cargandoMasks = false;
        InvalidateSurface();
    }

    private void CalcularCentroides()
    {
        _pines.Clear();
        foreach (var zona in _zonas)
        {
            if (!_masks.TryGetValue(zona.Id, out var alfas)) { _pines.Add(default); continue; }

            var minX = _mapaW; var minY = _mapaH;
            var maxX = 0; var maxY = 0;
            var hay = false;

            foreach (var alfa in alfas)
            {
                for (var y = 0; y < _mapaH; y++)
                {
                    var fila = y * _mapaW;
                    for (var x = 0; x < _mapaW; x++)
                    {
                        if (alfa[fila + x] <= UmbralAlfa) continue;
                        hay = true;
                        if (x < minX) minX = x;
                        if (x > maxX) maxX = x;
                        if (y < minY) minY = y;
                        if (y > maxY) maxY = y;
                    }
                }
            }

            _pines.Add(hay ? new SKPoint((minX + maxX) / 2f, (minY + maxY) / 2f) : default);
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

    public void ResaltarZonas(params string[] ids)
    {
        _resaltadas.Clear();
        foreach (var id in ids)
            if (!_resaltadas.Contains(id))
                _resaltadas.Add(id);
        InvalidateSurface();
    }

    public void LimpiarResaltado()
    {
        if (_resaltadas.Count == 0) return;
        _resaltadas.Clear();
        InvalidateSurface();
    }

    private void CambiarZoom(float factor)
    {
        _escala = Math.Clamp(_escala * factor, ZoomMin, ZoomMax);
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

        if (_pinActivo >= 0)
        {
            var pinOk = PosicionPinEnCanvas(_pinActivo, out var pinPos);
            if (pinOk && (EstaEnPin(punto, pinPos) || EstaEnPopup(punto, pinPos)))
            {
                var zona = _zonas[_pinActivo];
                _pinActivo = -1;
                ResaltarZonas(zona.Id);
                ZonaTocada?.Invoke(this, new ZonaTocadaEventArgs(new List<ZonaHit>
                {
                    new() { Id = zona.Id, Nombre = zona.Nombre, Color = zona.Color }
                }));
                InvalidateSurface();
                return;
            }
            _pinActivo = -1;
            InvalidateSurface();
        }

        for (var i = 0; i < _pines.Count; i++)
        {
            if (!PosicionPinEnCanvas(i, out var pos) || !EstaEnPin(punto, pos)) continue;
            _pinActivo = i;
            ResaltarZonas(_zonas[i].Id);
            Centrar();
            InvalidateSurface();
            return;
        }

        if (!TransformarAPuntoMapa(punto, out var mx, out var my)) return;

        if (mx < 0 || my < 0 || mx >= _mapaW || my >= _mapaH) return;

        var idx = (int)my * _mapaW + (int)mx;
        var golpes = new List<ZonaHit>();
        var vistos = new HashSet<string>();

        foreach (var zona in _zonas)
        {
            if (vistos.Contains(zona.Id)) continue;
            if (!_masks.TryGetValue(zona.Id, out var alfas)) continue;
            foreach (var alfa in alfas)
            {
                if (idx < alfa.Length && alfa[idx] > UmbralAlfa)
                {
                    golpes.Add(new ZonaHit { Id = zona.Id, Nombre = zona.Nombre, Color = zona.Color });
                    vistos.Add(zona.Id);
                    break;
                }
            }
        }

        if (golpes.Count == 0)
        {
            LimpiarResaltado();
            return;
        }

        ResaltarZonas(golpes.Select(g => g.Id).ToArray());
        Centrar();
        ZonaTocada?.Invoke(this, new ZonaTocadaEventArgs(golpes));
    }

    private bool TransformarAPuntoMapa(SKPoint punto, out int mx, out int my)
    {
        mx = 0; my = 0;
        if (_mapa == null || _canvasW <= 0 || _canvasH <= 0) return false;

        var escalaBase = Math.Min(_canvasW / (float)_mapaW, _canvasH / (float)_mapaH);
        var drawnW = _mapaW * escalaBase * _escala;
        var drawnH = _mapaH * escalaBase * _escala;
        var origenX = _canvasW / 2f - drawnW * _centroX;
        var origenY = _canvasH / 2f - drawnH * _centroY;

        mx = (int)((punto.X - origenX) * _mapaW / drawnW);
        my = (int)((punto.Y - origenY) * _mapaH / drawnH);
        return true;
    }

    private bool PosicionPinEnCanvas(int i, out SKPoint p)
    {
        p = default;
        if (_mapa == null || i < 0 || i >= _pines.Count) return false;

        var escalaBase = Math.Min(_canvasW / (float)_mapaW, _canvasH / (float)_mapaH);
        var drawnW = _mapaW * escalaBase * _escala;
        var drawnH = _mapaH * escalaBase * _escala;
        var origenX = _canvasW / 2f - drawnW * _centroX;
        var origenY = _canvasH / 2f - drawnH * _centroY;
        var pt = _pines[i];
        p = new SKPoint(origenX + pt.X * drawnW / _mapaW, origenY + pt.Y * drawnH / _mapaH);
        return true;
    }

    private static bool EstaEnPin(SKPoint punto, SKPoint pin) =>
        Math.Abs(punto.X - pin.X) <= PinRadioToque && Math.Abs(punto.Y - pin.Y) <= PinRadioToque;

    private bool EstaEnPopup(SKPoint punto, SKPoint pin)
    {
        ObtenerRectPopup(pin, out var rect);
        return rect.Contains(punto.X, punto.Y);
    }

    private void ObtenerRectPopup(SKPoint pin, out SKRect rect)
    {
        var x = Math.Clamp(pin.X - PopupAncho / 2f, 8f, Math.Max(8f, _canvasW - PopupAncho - 8f));
        var bottom = pin.Y - PinRadio * 2.4f;
        var top = bottom - PopupAlto;
        rect = new SKRect(x, top, x + PopupAncho, bottom);
    }

    private void DibujarPines(SKCanvas canvas)
    {
        for (var i = 0; i < _pines.Count; i++)
        {
            if (!PosicionPinEnCanvas(i, out var pos)) continue;
            DibujarPin(canvas, pos);
            if (i == _pinActivo) DibujarPopup(canvas, pos, _zonas[i].Nombre);
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

    private void DibujarPopup(SKCanvas canvas, SKPoint pin, string texto)
    {
        ObtenerRectPopup(pin, out var rect);

        using var sombra = new SKPaint
        {
            IsAntialias = true,
            ImageFilter = SKImageFilter.CreateDropShadow(0, 3, 8, 6, new SKColor(0, 0, 0, 60))
        };
        using var fondo = new SKPaint { IsAntialias = true, Color = SKColors.White };
        using var flecha = new SKPaint { IsAntialias = true, Color = SKColors.White };
        using var colorTitulo = new SKPaint { IsAntialias = true, Color = SKColor.Parse("#1E293B") };
        using var colorSub = new SKPaint { IsAntialias = true, Color = SKColor.Parse("#475569") };
        using var tipoTitulo = SKTypeface.FromFamilyName("OpenSansSemibold");
        using var fontTitulo = new SKFont(tipoTitulo, 14);
        using var fontSub = new SKFont(SKTypeface.Default, 11);

        canvas.DrawRoundRect(rect, 12, 12, sombra);
        canvas.DrawRoundRect(rect, 12, 12, fondo);

        using var flechaPath = new SKPath();
        flechaPath.MoveTo(rect.MidX - 9, rect.Bottom);
        flechaPath.LineTo(rect.MidX + 9, rect.Bottom);
        flechaPath.LineTo(rect.MidX, rect.Bottom + 11);
        flechaPath.Close();
        canvas.DrawPath(flechaPath, flecha);

        var cyTexto = rect.Top + PopupAlto / 2f - 4f;
        canvas.DrawText(texto, rect.MidX, cyTexto, SKTextAlign.Center, fontTitulo, colorTitulo);
        canvas.DrawText("Ver zona", rect.MidX, cyTexto + 15f, SKTextAlign.Center, fontSub, colorSub);
    }

    private void OnPaintSurface(object? sender, SKPaintSurfaceEventArgs e)
    {
        _canvasW = e.Info.Width;
        _canvasH = e.Info.Height;
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColor.Parse("#030F26"));

        if (_mapa == null) return;

        var escalaBase = Math.Min(e.Info.Width / (float)_mapaW, e.Info.Height / (float)_mapaH);
        var drawnW = _mapaW * escalaBase * _escala;
        var drawnH = _mapaH * escalaBase * _escala;
        var origenX = e.Info.Width / 2f - drawnW * _centroX;
        var origenY = e.Info.Height / 2f - drawnH * _centroY;
        var destino = new SKRect(origenX, origenY, origenX + drawnW, origenY + drawnH);

        canvas.DrawBitmap(_mapa, destino);

        DibujarZonasResaltadas(canvas, destino);
        DibujarPines(canvas);
    }

    private void DibujarZonasResaltadas(SKCanvas canvas, SKRect destino)
    {
        if (_resaltadas.Count == 0) return;

        foreach (var zona in _zonas)
        {
            if (!_resaltadas.Contains(zona.Id) || zona.Bitmaps.Count == 0) continue;

            var r = zona.Color.Red / 255f;
            var g = zona.Color.Green / 255f;
            var b = zona.Color.Blue / 255f;

            using var paint = new SKPaint
            {
                IsAntialias = true,
                ColorFilter = SKColorFilter.CreateColorMatrix(new[]
                {
                    0f, 0, 0, 0, r,
                    0, 0, 0, 0, g,
                    0, 0, 0, 0, b,
                    0, 0, 0, 0.85f, 0
                })
            };
            foreach (var bmp in zona.Bitmaps)
                canvas.DrawBitmap(bmp, destino, paint);
        }
    }
}