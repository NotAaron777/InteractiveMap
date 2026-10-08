using MapaInteractivo.Maui.Models;

namespace MapaInteractivo.Maui.Views;

public partial class CaciqueRowView : ContentView
{
    public CaciqueRowView()
    {
        InitializeComponent();
    }

    private async void OnTapped(object? sender, TappedEventArgs e)
    {
        if (BindingContext is Cacique cacique)
        {
            await Shell.Current.GoToAsync($"cacique?id={cacique.Id}");
        }
    }
}