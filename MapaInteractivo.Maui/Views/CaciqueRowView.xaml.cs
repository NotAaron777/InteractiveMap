using MapaInteractivo.Maui.Models;

namespace MapaInteractivo.Maui.Views;

public partial class CaciqueRowView : ContentView
{
    public CaciqueRowView()
    {
        InitializeComponent();
        BindingContextChanged += OnBindingContextChanged;
    }

    private void OnBindingContextChanged(object? sender, EventArgs e) => AplicarAvatar();

    // Muestra la foto del cacique si tiene un archivo válido; si no, deja las iniciales.
    private void AplicarAvatar()
    {
        if (BindingContext is not Cacique cacique) return;

        var imagen = cacique.Imagen?.Trim();

        if (string.IsNullOrEmpty(imagen))
        {
            // Fallback: si no hay foto, se muestran las iniciales
            imgCacique.Source = null;
            imgCacique.IsVisible = false;
            lblIniciales.IsVisible = true;
            return;
        }

        imgCacique.Source = ImageSource.FromFile(imagen);
        imgCacique.IsVisible = true;
        lblIniciales.IsVisible = false;
    }

    private async void OnTapped(object? sender, TappedEventArgs e)
    {
        if (BindingContext is Cacique cacique)
        {
            await Shell.Current.GoToAsync($"cacique?id={cacique.Id}");
        }
    }
}