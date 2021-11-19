namespace Smart.Forms.Markup;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[ContentProperty("Value")]
public sealed class BoolExtension : IMarkupExtension
{
    public bool Value { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider) => Value;
}
