using MapaInteractivo.Maui.Models;
using MapaInteractivo.Maui.Services;

namespace MapaInteractivo.Maui.Views;

public partial class AcercaPage : ContentPage
{
    private readonly JsonDataService _datos;
    private bool _cargado;

    public AcercaPage(JsonDataService datos)
    {
        InitializeComponent();
        _datos = datos;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_cargado) return;
        await _datos.CargarAsync();

        var model = new AcercaPageModel
        {
            Caciques = _datos.Caciques.ToList(),
            Referencias = _datos.Fuentes.Referencias
                .Select(t => new Seccion { Titulo = "", Texto = t })
                .ToList(),
            Creditos = _datos.Fuentes.Creditos,
        };
        BindingContext = model;
        gridCaciques.ItemsSource = model.Caciques;

        _cargado = true;
    }

    private async void OnTerritoriosCompartidos(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("region?id=territorios-compartidos");
    }

    private async void OnCronologia(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//cronologia");
    }

    private async void OnMapa(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//mapa");
    }
}