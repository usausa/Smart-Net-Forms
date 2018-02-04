namespace Smart.Forms.Markup
{
    using System;
    using Xamarin.Forms.Xaml;

    public class Int16Extension : IMarkupExtension
    {
        public short Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
