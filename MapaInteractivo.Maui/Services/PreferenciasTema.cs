namespace MapaInteractivo.Maui.Services;

public static class PreferenciasTema
{
    private const string Clave = "tema_oscuro";

    public static string Tema
    {
        get => Preferences.Default.Get(Clave, "off");
        set
        {
            Preferences.Default.Set(Clave, value);
            Aplicar(value);
        }
    }

    public static void Aplicar(string tema)
    {
        var theme = tema switch
        {
            "on" => AppTheme.Dark,
            "off" => AppTheme.Light,
            _ => AppTheme.Unspecified,
        };
        Application.Current!.UserAppTheme = theme;
    }
}