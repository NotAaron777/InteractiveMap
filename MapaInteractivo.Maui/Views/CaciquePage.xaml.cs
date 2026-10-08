using MapaInteractivo.Maui.Models;
using MapaInteractivo.Maui.Services;

namespace MapaInteractivo.Maui.Views;

public partial class CaciquePage : ContentPage, IQueryAttributable
{
    private readonly JsonDataService _datos;

    public CaciquePage(JsonDataService datos)
    {
        InitializeComponent();
        _datos = datos;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("id", out var id) || id is not string caciqueId) return;
        await _datos.CargarAsync();
        var cacique = _datos.CaciquePorId(caciqueId);
        if (cacique == null)
        {
            await DisplayAlertAsync("Cacique", "No se encontró la figura solicitada.", "OK");
            await Shell.Current.GoToAsync("..");
            return;
        }

        lblNombre.Text = cacique.Nombre;
        lblIniciales.Text = cacique.Iniciales;
        lblPuebloPeriodo.Text = string.IsNullOrWhiteSpace(cacique.Periodo)
            ? cacique.Pueblo
            : $"{cacique.Pueblo} · {cacique.Periodo}";
        if (Color.TryParse(cacique.Color ?? "#B541FA", out var color))
            encabezadoColor.BackgroundColor = color;

        AplicarAvatar(cacique);

        BindingContext = new CaciquePageModel
        {
            Cacique = cacique,
            Secciones = _datos.Secciones(cacique),
        };
    }

    // Muestra la imagen del cacique si tiene un archivo válido; si no, deja las iniciales.
    private void AplicarAvatar(Cacique cacique)
    {
        var imagen = cacique.Imagen?.Trim();

        if (string.IsNullOrEmpty(imagen))
        {
            // Fallback: caciques sin imagen (p. ej. Chontal y Adiac tienen "imagen": "")
            imgCacique.Source = null;
            imgCacique.IsVisible = false;
            lblIniciales.IsVisible = true;
            return;
        }

        imgCacique.Source = ImageSource.FromFile(imagen);
        imgCacique.IsVisible = true;
        lblIniciales.IsVisible = false;
    }
}