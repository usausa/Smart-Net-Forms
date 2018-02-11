﻿namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class ConditionConverter : IValueConverter
    {
        /// <summary>
        ///
        /// </summary>
        public Func<object, bool> Predicate { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object TrueValue { get; set; }

        /// <summary>
        ///
        /// </summary>
        public object FalseValue { get; set; }

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
            return (Predicate?.Invoke(value) ?? (bool)value) ? TrueValue : FalseValue;
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
            return Equals(value, TrueValue);
        }
    }
}
