﻿namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Xamarin.Forms;

    public sealed class NullToObjectConverter<T> : IValueConverter
    {
        public T NullValue { get; set; }

        public T NonNullValue { get; set; }

        public bool HandleEmptyString { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is null) ||
                (HandleEmptyString && String.IsNullOrEmpty(value as string)))
            {
                return NullValue;
            }

            return NonNullValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
