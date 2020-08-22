namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    public sealed class IndexToArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is int index) && (parameter is Array array))
            {
                return array.GetValue(index);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Array array)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    var element = array.GetValue(i);
                    if (((element != null) && element.Equals(value)) ||
                         ((element == null) && (value == null)))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}
