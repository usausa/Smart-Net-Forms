﻿namespace Smart.Forms.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Xamarin.Forms;

    public sealed class AggregateConverter : List<IValueConverter>, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Aggregate(value, (current, converter) => converter.Convert(current, targetType, parameter, culture));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
