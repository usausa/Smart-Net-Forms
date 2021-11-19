namespace Smart.Forms.Data;

using System;
using System.Globalization;

using Xamarin.Forms;

public sealed class TappedItemIndexConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is ItemTappedEventArgs eventArgs ? eventArgs.ItemIndex : -1;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
