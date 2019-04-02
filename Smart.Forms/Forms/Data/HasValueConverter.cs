namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public sealed class HasValueConverter : IValueConverter
    {
        public bool NullToTrue { get; set; }

        public bool HandleEmptyString { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is null) ||
                (HandleEmptyString && String.IsNullOrEmpty(value as string)))
            {
                return NullToTrue;
            }

            return !NullToTrue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
