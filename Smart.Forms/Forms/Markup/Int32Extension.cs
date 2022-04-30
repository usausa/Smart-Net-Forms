namespace Smart.Forms.Markup;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[ContentProperty("Value")]
public sealed class Int32Extension : IMarkupExtension
{
    public int Value { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider) => Value;
}
