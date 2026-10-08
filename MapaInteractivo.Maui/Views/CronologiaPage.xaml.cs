using MapaInteractivo.Maui.Services;

namespace MapaInteractivo.Maui.Views;

public partial class CronologiaPage : ContentPage
{
    private readonly JsonDataService _datos;
    private bool _cargado;

    private double _escalaTimeline = 1d;
    private double _escalaInicial = 1d;

    public CronologiaPage(JsonDataService datos)
    {
        InitializeComponent();
        _datos = datos;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_cargado) return;
        await _datos.CargarAsync();
        listCronologia.ItemsSource = _datos.Cronologia;
        _cargado = true;
    }

    private void OnContenidoZoom(object? sender, PinchGestureUpdatedEventArgs e)
    {
        switch (e.Status)
        {
            case GestureStatus.Started:
                _escalaInicial = _escalaTimeline;
                break;

            case GestureStatus.Running:
            case GestureStatus.Completed:
                _escalaTimeline = Math.Clamp(_escalaInicial * e.Scale, 1d, 3d);
                contenidoZoom.Scale = _escalaTimeline;
                btnRestaurarZoom.IsVisible = _escalaTimeline > 1.01;
                break;
        }
    }

    private void OnRestablecerZoom(object? sender, EventArgs e)
    {
        _escalaTimeline = 1d;
        contenidoZoom.Scale = 1d;
        btnRestaurarZoom.IsVisible = false;
    }
}
