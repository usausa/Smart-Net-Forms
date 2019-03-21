namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class NullToObjectConverter<T> : IValueConverter
    {
        /// <summary>
        ///
        /// </summary>
        public T NullValue { get; set; }

        /// <summary>
        ///
        /// </summary>
        public T NonValue { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool HandleEmptyString { get; set; }

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
            if ((value == null) ||
                (HandleEmptyString && String.IsNullOrEmpty(value as string)))
            {
                return NullValue;
            }

            return NullValue;
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
