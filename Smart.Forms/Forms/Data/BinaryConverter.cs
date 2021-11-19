namespace Smart.Forms.Data;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Smart.Forms.Expressions;

using Xamarin.Forms;

public sealed class BinaryConverter : IValueConverter
{
    [AllowNull]
    public IBinaryExpression Expression { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Expression.Eval(value, parameter);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
