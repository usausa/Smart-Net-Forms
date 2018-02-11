namespace Smart.Forms.Markup
{
    using System;
    using Xamarin.Forms.Xaml;

    public sealed class Int64Extension : IMarkupExtension
    {
        public long Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }
}
