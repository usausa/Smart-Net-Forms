namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    public sealed class ObjectToBooleanConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }

        public T FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T typedValue && Equals(typedValue, TrueValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool boolValue && boolValue ? TrueValue : FalseValue;
        }
    }
}