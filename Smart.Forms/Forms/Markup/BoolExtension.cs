namespace Smart.Forms.Markup
{
    using System;
    using Xamarin.Forms.Xaml;

    public class BoolExtension : IMarkupExtension
    {
        public bool Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
