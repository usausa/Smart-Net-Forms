namespace Smart.Forms.Markup
{
    using System;
    using Xamarin.Forms.Xaml;

    public sealed class FloatExtension : IMarkupExtension
    {
        public float Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
