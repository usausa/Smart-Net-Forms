namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Smart.Converter;

    using Xamarin.Forms;

    public sealed class ObjectConvertConverter : IValueConverter
    {
        public IObjectConverter Converter { get; set; } = ObjectConverter.Default;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter.Convert(value, targetType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Converter.Convert(value, targetType);
        }
    }
}
