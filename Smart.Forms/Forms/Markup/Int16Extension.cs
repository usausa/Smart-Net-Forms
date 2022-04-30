namespace Smart.Forms.Markup;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[ContentProperty("Value")]
public sealed class Int16Extension : IMarkupExtension
{
    public short Value { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider) => Value;
}
