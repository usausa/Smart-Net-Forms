namespace Smart.Forms.Markup;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[ContentProperty("Value")]
public sealed class FloatExtension : IMarkupExtension
{
    public float Value { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider) => Value;
}
