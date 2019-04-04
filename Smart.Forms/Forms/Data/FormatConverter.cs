namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public sealed class FormatConverter : IValueConverter
    {
        public string Format { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return string.Empty;
            }

            if (value is IFormattable formattable)
            {
                return formattable.ToString(Format, culture);
            }

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
