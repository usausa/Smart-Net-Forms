namespace Smart.Forms.Data
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using Smart.Forms.Expressions;

    using Xamarin.Forms;

    public sealed class MultiBinaryConverter : IMultiValueConverter
    {
        [AllowNull]
        public IBinaryExpression Expression { get; set; }

        public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
        {
            var value = values[0];
            for (var i = 1; i < values.Length; i++)
            {
                value = Expression.Eval(value, values[i]);
            }

            return value;
        }

        public object?[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
