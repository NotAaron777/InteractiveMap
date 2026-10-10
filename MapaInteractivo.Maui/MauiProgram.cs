using MapaInteractivo.Maui.Services;
using MapaInteractivo.Maui.Views;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MapaInteractivo.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Poppins-SemiBold.ttf", "DisplayFont");
				fonts.AddFont("MaterialIcons.ttf", "MaterialIcons");
			});

		builder.Services.AddSingleton<JsonDataService>();
		builder.Services.AddTransient<MapaPage>();
		builder.Services.AddTransient<MapaHistoricoPage>();
		builder.Services.AddTransient<CronologiaPage>();
		builder.Services.AddTransient<AcercaPage>();
		builder.Services.AddTransient<ConfigPage>();
		builder.Services.AddTransient<RegionPage>();
		builder.Services.AddTransient<CaciquePage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}