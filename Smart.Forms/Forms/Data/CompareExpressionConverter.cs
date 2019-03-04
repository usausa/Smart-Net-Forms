namespace Smart.Forms.Data
{
    using System;
    using System.Globalization;

    using Smart.Forms.Expressions;

    using Xamarin.Forms;

    public sealed class CompareExpressionConverter : IValueConverter
    {
        public ICompareExpression Expression { get; set; } = CompareExpressions.Equal;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Expression.Eval(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
