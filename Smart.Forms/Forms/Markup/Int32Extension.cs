namespace Smart.Forms.Markup
{
    using System;
    using Xamarin.Forms.Xaml;

    public class Int32Extension : IMarkupExtension
    {
        public int Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
