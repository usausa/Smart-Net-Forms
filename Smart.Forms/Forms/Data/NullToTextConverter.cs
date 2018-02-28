﻿namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class NullToTextConverter : IValueConverter
    {
        /// <summary>
        ///
        /// </summary>
        public string NullText { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string NonNullText { get; set; }

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
            return value == null ? NullText : NonNullText;
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
