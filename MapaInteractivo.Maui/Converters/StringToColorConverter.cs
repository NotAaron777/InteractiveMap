using System.Globalization;

namespace MapaInteractivo.Maui.Converters;

public class StringToColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string hex && Color.TryParse(hex, out var color))
            return new SolidColorBrush(color);
        return new SolidColorBrush(Colors.Transparent);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}