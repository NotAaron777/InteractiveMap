using System.Globalization;

namespace MapaInteractivo.Maui.Converters;

public class PastelColorConverter : IValueConverter
{
    private static readonly Dictionary<string, Color> Pasteles = new()
    {
        ["#4FD2E9"] = Color.FromArgb("#E0F2FE"), // cian (Nicarao, Nicoya)
        ["#B541FA"] = Color.FromArgb("#F3E8FF"), // morado (Diriangén, Tenderí, Adiac)
        ["#176A96"] = Color.FromArgb("#DCEFFA"), // azul claro (Agateyte)
        ["#263995"] = Color.FromArgb("#E8ECF9"), // índigo claro (Yaguare)
        ["#74706D"] = Color.FromArgb("#EEF1F5"), // gris (Chontal)
    };

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string hex && Pasteles.TryGetValue(hex.ToUpperInvariant(), out var pastel))
            return pastel;
        return Color.FromArgb("#F0F3F8");
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}