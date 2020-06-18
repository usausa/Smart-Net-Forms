namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;
    using System.Linq;

    using Xamarin.Forms;

    public sealed class AllConverter : IMultiValueConverter
    {
        public bool Invert { get; set; }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.All(value => System.Convert.ToBoolean(value, culture)) ? !Invert : Invert;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
