namespace Smart.Forms.Data;

using System.Globalization;

using Xamarin.Forms;

public sealed class TappedItemConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is ItemTappedEventArgs eventArgs ? eventArgs.Item : null;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
