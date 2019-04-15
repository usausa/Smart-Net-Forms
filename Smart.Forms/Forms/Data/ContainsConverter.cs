namespace Smart.Forms.Data
{
    using System;
    using System.Collections;
    using System.Globalization;

    using Xamarin.Forms;

    public sealed class ContainsConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }

        public T FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter is IList list && list.Contains(value) ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
