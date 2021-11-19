namespace Smart.Forms.Markup;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[ContentProperty("Value")]
public sealed class DoubleExtension : IMarkupExtension
{
    public double Value { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider) => Value;
}
