namespace Smart.Forms.Data;

using System.Globalization;

using Xamarin.Forms;

public sealed class NullToObjectConverter<T> : IValueConverter
{
    public T NullValue { get; set; } = default!;

    public T NonNullValue { get; set; } = default!;

    public bool HandleEmptyString { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if ((value is null) ||
            (HandleEmptyString && value is string { Length: 0 }))
        {
            return NullValue;
        }

        return NonNullValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
