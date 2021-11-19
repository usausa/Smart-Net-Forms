namespace Smart.Forms.Data;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Smart.Forms.Expressions;

using Xamarin.Forms;

public sealed class CompareConverter<T> : IValueConverter
{
    [AllowNull]
    public T TrueValue { get; set; }

    [AllowNull]
    public T FalseValue { get; set; }

    public ICompareExpression Expression { get; set; } = CompareExpressions.Equal;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Expression.Eval(value, parameter) ? TrueValue : FalseValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
