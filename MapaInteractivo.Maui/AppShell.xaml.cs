using MapaInteractivo.Maui.Views;

namespace MapaInteractivo.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("region", typeof(RegionPage));
		Routing.RegisterRoute("cacique", typeof(CaciquePage));
	}
}