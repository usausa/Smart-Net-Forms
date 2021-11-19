namespace Smart.Forms.Data;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xamarin.Forms;

public sealed class BoolToObjectConverter<T> : IValueConverter
{
    [AllowNull]
    public T TrueValue { get; set; }

    [AllowNull]
    public T FalseValue { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? TrueValue : FalseValue;
        }

        return FalseValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Equals(value, TrueValue);
    }
}
