using MapaInteractivo.Maui.Controls;
using MapaInteractivo.Maui.Models;
using MapaInteractivo.Maui.Services;
using SkiaSharp;

namespace MapaInteractivo.Maui.Views;

public partial class MapaPage : ContentPage
{
    private readonly JsonDataService _datos;
    private bool _mapaListo;

    public MapaPage(JsonDataService datos)
    {
        InitializeComponent();
        _datos = datos;
        mapa.ZonaTocada += OnZonaTocada;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_mapaListo) return;

        await _datos.CargarAsync();

        ConfigurarZonas();
        await mapa.CargarAsync();
        _mapaListo = true;
    }

    private void ConfigurarZonas()
    {
        var azul = SKColor.Parse("#176A96");
        var purpura = SKColor.Parse("#B541FA");
        var cian = SKColor.Parse("#4FD2E9");
        var verde = SKColor.Parse("#2F9E44");
        var ambar = SKColor.Parse("#E88F1F");

        mapa.AgregarZona("miskito", "Miskito", azul, "miskito.png");
        mapa.AgregarZona("mayangna", "Mayangna", azul, "mayangna.png");
        mapa.AgregarZona("ulwa", "Ulwa", cian, "ulwas.png");
        mapa.AgregarZona("rama", "Rama", verde, "rama.png");
        mapa.AgregarZona("creole", "Creole", purpura, "creole.png", "rama_creole.png");
        mapa.AgregarZona("chorotega", "Chorotega", ambar, "chorotega.png");
        mapa.AgregarZona("matagalpa", "Matagalpa", verde, "matagalpa.png");
        mapa.AgregarZona("nahoas", "Nahoas", purpura, "nahoas.png");
        mapa.AgregarZona("xiu", "Xiu-Sutiaba", azul, "xiu.png");
    }

    private async void OnZonaTocada(object? sender, ZonaTocadaEventArgs e)
    {
        if (e.Multiple)
        {
            var opciones = e.Zonas.Select(z => z.Nombre).ToArray();
            var elegido = await DisplayActionSheetAsync("Zona compartida", "Cancelar", null, opciones);
            if (string.IsNullOrEmpty(elegido) || elegido == "Cancelar") return;
            var zona = e.Zonas.FirstOrDefault(z => z.Nombre == elegido);
            if (zona != null) await NavegarRegion(zona.Id);
            return;
        }

        await NavegarRegion(e.Zonas[0].Id);
    }

    private async Task NavegarRegion(string id)
    {
        await Shell.Current.GoToAsync($"region?id={id}");
    }

    private async void OnBuscar(object? sender, EventArgs e)
    {
        var termino = sbBuscar.Text?.Trim();
        if (string.IsNullOrWhiteSpace(termino))
        {
            await DisplayAlertAsync("Buscar", "Escribe el nombre de un cacique o lugar.", "OK");
            return;
        }

        var t = termino.ToLowerInvariant();
        var regiones = _datos.Regiones
            .Where(r => r.Id != "territorios-compartidos" &&
                        (r.Nombre.ToLowerInvariant().Contains(t) || r.Id.ToLowerInvariant().Contains(t)))
            .ToList();
        var caciques = _datos.Caciques
            .Where(c =>
                c.Nombre.ToLowerInvariant().Contains(t) ||
                c.Pueblo.ToLowerInvariant().Contains(t) ||
                (c.Territorio ?? "").ToLowerInvariant().Contains(t))
            .ToList();

        if (regiones.Count + caciques.Count == 1)
        {
            if (regiones.Count == 1) await NavegarRegion(regiones[0].Id);
            else await Shell.Current.GoToAsync($"cacique?id={caciques[0].Id}");
            return;
        }

        if (regiones.Count + caciques.Count == 0)
        {
            await DisplayAlertAsync("Buscar", "No se encontraron resultados.", "OK");
            return;
        }

        var opciones = regiones.Select(r => r.Nombre).Concat(caciques.Select(c => c.Nombre)).ToArray();
        var elegido = await DisplayActionSheetAsync("Resultados", "Cancelar", null, opciones);
        if (string.IsNullOrEmpty(elegido) || elegido == "Cancelar") return;

        var region = regiones.FirstOrDefault(r => r.Nombre == elegido);
        if (region != null) { await NavegarRegion(region.Id); return; }
        var cacique = caciques.FirstOrDefault(c => c.Nombre == elegido);
        if (cacique != null) await Shell.Current.GoToAsync($"cacique?id={cacique.Id}");
    }

    private async void OnFiltro(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("Filtro",
            "Esta versión muestra todos los territorios. La búsqueda permite encontrar caciques, pueblos y lugares por nombre.",
            "OK");
    }

    private void OnAcercar(object? sender, EventArgs e) => mapa.Acercar();
    private void OnAlejar(object? sender, EventArgs e) => mapa.Alejar();

    private void OnCentrar(object? sender, EventArgs e) => mapa.Centrar();
}