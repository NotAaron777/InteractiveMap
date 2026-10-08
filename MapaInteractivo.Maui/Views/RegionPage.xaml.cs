using MapaInteractivo.Maui.Models;
using MapaInteractivo.Maui.Services;

namespace MapaInteractivo.Maui.Views;

public partial class RegionPage : ContentPage, IQueryAttributable
{
    private readonly JsonDataService _datos;

    public RegionPage(JsonDataService datos)
    {
        InitializeComponent();
        _datos = datos;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("id", out var id) || id is not string regionId) return;
        await _datos.CargarAsync();
        var region = _datos.RegionPorId(regionId);
        if (region == null)
        {
            await DisplayAlertAsync("Región", "No se encontró la región solicitada.", "OK");
            await Shell.Current.GoToAsync("..");
            return;
        }

        lblNombre.Text = region.Nombre;
        lblSubtitulo.Text = region.Subtitulo;
        if (Color.TryParse(region.Color ?? "#192584", out var color))
            encabezadoColor.BackgroundColor = color;

        var model = new RegionPageModel
        {
            Region = region,
            Secciones = _datos.Secciones(region),
            Caciques = _datos.CaciquesDeRegion(region.Id),
        };
        BindingContext = model;

        lblCaciquesTitulo.IsVisible = model.Caciques.Count > 0;
    }

    private async void OnCaciqueTocado(object? sender, TappedEventArgs e)
    {
        if (sender is not BindableObject b || b.BindingContext is not Cacique cacique) return;
        await Shell.Current.GoToAsync($"cacique?id={cacique.Id}");
    }
}