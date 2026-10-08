namespace MapaInteractivo.Maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Services.PreferenciasTema.Aplicar(Services.PreferenciasTema.Tema);
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}