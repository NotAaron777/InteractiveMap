using MapaInteractivo.Maui.Controls;
using MapaInteractivo.Maui.Services;
using SkiaSharp;
using Region = MapaInteractivo.Maui.Models.Region;

namespace MapaInteractivo.Maui.Views;

/// <summary>
/// Página del mapa histórico de los pueblos originarios de Nicaragua.
///
/// Independiente de <see cref="MapaPage"/>: no comparte control ni máscaras con el
/// mapa interactivo. Reutiliza la imagen base del proyecto y los datos históricos
/// de "regiones.json", y usa las máscaras históricas dibujadas por el autor
/// (Resources/mascaras, empaquetadas bajo "MascarasHistoricas/").
/// </summary>
public partial class MapaHistoricoPage : ContentPage
{
    private readonly JsonDataService _datos;
    private bool _mapaListo;

    private string _regionSeleccionada = "";

    // Correspondencia entre los territorios históricos (máscaras de Resources/mascaras)
    // y las regiones con datos en regiones.json. Asignación confirmada con el autor:
    // - chorotega -> chorotega
    // - maribio   -> xiu (Xiu-Sutiaba)
    // - misulpas  -> macroterritorio de los pueblos Misumalpa (miskito, mayangna, ulwa, matagalpa)
    // - nicarao   -> nahoas (Nahoa-Nicarao)
    // - rama      -> rama
    private static readonly Dictionary<string, string[]> RegionesPorTerritorio = new()
    {
        ["chorotega"] = new[] { "chorotega" },
        ["maribio"] = new[] { "xiu" },
        ["misulpas"] = new[] { "miskito", "mayangna", "ulwa", "matagalpa" },
        ["nicarao"] = new[] { "nahoas" },
        ["rama"] = new[] { "rama" },
    };

    public MapaHistoricoPage(JsonDataService datos)
    {
        InitializeComponent();
        _datos = datos;
        mapa.TerritorioTocado += OnTerritorioTocado;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_mapaListo) return;

        await _datos.CargarAsync();

        ConfigurarTerritorios();
        await mapa.CargarAsync();
        _mapaListo = true;
    }

    private void ConfigurarTerritorios()
    {
        // Colores claramente diferenciados por matiz y consistentes con la app:
        // cada territorio usa el color de la región a la que está mapeado en
        // regiones.json (chorotega #E88F1F, xiu #263995, nahoas #B541FA, rama #2F9E44),
        // y misulpas (macroterritorio Misumalpa) el cian de la familia caribeña #4FD2E9.
        var ambar = SKColor.Parse("#E88F1F");
        var azulNoche = SKColor.Parse("#263995");
        var cian = SKColor.Parse("#4FD2E9");
        var purpura = SKColor.Parse("#B541FA");
        var verde = SKColor.Parse("#2F9E44");

        // El macroterritorio se registra primero para que, en las zonas de
        // superposición, los territorios específicos se dibujen encima
        // (solo cambia el orden de pintado, no los contornos ni las posiciones).
        mapa.AgregarTerritorio("misulpas", "Misulpas", cian, "misulpas.png");
        mapa.AgregarTerritorio("chorotega", "Chorotega", ambar, "chorotega.png");
        mapa.AgregarTerritorio("maribio", "Maribio", azulNoche, "maribio.png");
        mapa.AgregarTerritorio("nicarao", "Nicarao", purpura, "nicarao.png");
        mapa.AgregarTerritorio("rama", "Rama", verde, "rama.png");
    }

    private async void OnTerritorioTocado(object? sender, TerritorioTocadoEventArgs e)
    {
        if (e.Territorios.Count == 0) return;

        var territorio = e.Territorios[0];

        // Los territorios históricos se superponen en algunas zonas
        // (p. ej. chorotega/maribio en el occidente, misulpas con varios en el centro).
        if (e.Multiple)
        {
            var opciones = e.Territorios.Select(t => t.Nombre).ToArray();
            var elegido = await DisplayActionSheetAsync("Territorios superpuestos", "Cancelar", null, opciones);
            if (string.IsNullOrEmpty(elegido) || elegido == "Cancelar") return;
            territorio = e.Territorios.FirstOrDefault(t => t.Nombre == elegido) ?? territorio;
        }

        MostrarPanel(territorio);
    }

    private void MostrarPanel(TerritorioHit territorio)
    {
        if (!RegionesPorTerritorio.TryGetValue(territorio.Id, out var ids)) return;

        var color = Color.FromRgb(territorio.Color.Red, territorio.Color.Green, territorio.Color.Blue);
        dotTerritorio.BackgroundColor = color;
        lblNombreTerritorio.Text = territorio.Nombre;

        var regiones = ids
            .Select(id => _datos.RegionPorId(id))
            .Where(r => r != null)
            .Select(r => r!)
            .ToList();

        if (regiones.Count == 1)
        {
            var region = regiones[0];
            _regionSeleccionada = region.Id;

            lblSubtituloTerritorio.Text = region.Subtitulo;
            lblRegionDatos.Text = $"Información histórica de: {region.Nombre}";

            panelUnico.IsVisible = true;
            panelMultiple.IsVisible = false;
            btnVerCompleta.IsVisible = true;

            panelPueblos.IsVisible = !string.IsNullOrWhiteSpace(region.Pueblos);
            lblPueblos.Text = region.Pueblos ?? "";

            panelHistoria.IsVisible = !string.IsNullOrWhiteSpace(region.Historia);
            lblHistoria.Text = region.Historia ?? "";

            BindableLayout.SetItemsSource(stPueblos, null);
        }
        else
        {
            _regionSeleccionada = "";

            lblSubtituloTerritorio.Text = "Macroterritorio compartido por varios pueblos";

            panelUnico.IsVisible = false;
            panelMultiple.IsVisible = true;
            btnVerCompleta.IsVisible = false;

            BindableLayout.SetItemsSource(stPueblos, regiones);
        }

        panelInfo.IsVisible = true;
    }

    private void OnCerrarPanel(object? sender, EventArgs e)
    {
        panelInfo.IsVisible = false;
        mapa.LimpiarResaltado();
    }

    private async void OnRegionTocada(object? sender, TappedEventArgs e)
    {
        if (sender is BindableObject b && b.BindingContext is Region region)
            await IrARegion(region.Id);
    }

    private async void OnVerCompleta(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(_regionSeleccionada))
            await IrARegion(_regionSeleccionada);
    }

    private static async Task IrARegion(string id)
    {
        await Shell.Current.GoToAsync($"region?id={id}");
    }

    private void OnAcercar(object? sender, EventArgs e) => mapa.Acercar();
    private void OnAlejar(object? sender, EventArgs e) => mapa.Alejar();

    private void OnCentrar(object? sender, EventArgs e)
    {
        mapa.Centrar();
        panelInfo.IsVisible = false;
        mapa.LimpiarResaltado();
    }
}
