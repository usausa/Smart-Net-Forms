namespace Smart.Forms.Markup
{
    using System;
    using Xamarin.Forms.Xaml;

    public class DoubleExtension : IMarkupExtension
    {
        public double Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
