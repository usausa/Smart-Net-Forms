namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    public sealed class ParameterEqualsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Equals(value, true) ? parameter : null;
        }
    }
}
