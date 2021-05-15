namespace Smart.Forms.Data
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using Xamarin.Forms;

    public sealed class ObjectToBoolConverter<T> : IValueConverter
    {
        [AllowNull]
        public T TrueValue { get; set; }

        [AllowNull]
        public T FalseValue { get; set; }

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is T typedValue && Equals(typedValue, TrueValue);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is true ? TrueValue : FalseValue;
        }
    }
}
