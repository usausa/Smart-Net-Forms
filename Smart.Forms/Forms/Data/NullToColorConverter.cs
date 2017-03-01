namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class NullToColorConverter : IValueConverter
    {
        /// <summary>
        ///
        /// </summary>
        public Color NullColor { get; set; } = Color.Transparent;

        /// <summary>
        ///
        /// </summary>
        public Color NonNullColor { get; set; } = Color.Transparent;

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? NullColor : NonNullColor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
