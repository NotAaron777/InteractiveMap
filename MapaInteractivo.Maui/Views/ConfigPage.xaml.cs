using MapaInteractivo.Maui.Services;

namespace MapaInteractivo.Maui.Views;

public partial class ConfigPage : ContentPage
{
    public ConfigPage()
    {
        InitializeComponent();
        swOscuro.IsToggled = PreferenciasTema.Tema == "on";
    }

    private void OnOscuroCambiado(object? sender, ToggledEventArgs e)
    {
        PreferenciasTema.Tema = e.Value ? "on" : "off";
    }

    private async void OnNotificaciones(object? sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Notificaciones",
            "La gestión de notificaciones está disponible en versiones futuras.", "OK");
    }

    private async void OnPrivacidad(object? sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Privacidad y datos",
            "Esta aplicación funciona sin conexión: todo el contenido se carga desde archivos JSON locales. No se recopila ni envía ningún dato personal.", "OK");
    }

    private async void OnAyuda(object? sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Ayuda y soporte",
            "Toca una zona en el mapa para ver el pueblo y sus caciques. Usa la búsqueda para encontrar lugares y figuras por nombre.", "OK");
    }

    private async void OnLicencias(object? sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Licencias y créditos",
            ".NET MAUI · SkiaSharp · CommunityToolkit.Mvvm\nContenido histórico elaborado a partir de fuentes académicas (ver Referencias en la pestaña Acerca).", "OK");
    }

    private async void OnCerrarSesion(object? sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Cerrar sesión",
            "La aplicación no requiere una cuenta para usarse.", "OK");
    }
}