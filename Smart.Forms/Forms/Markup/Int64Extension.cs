namespace Smart.Forms.Markup
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("Value")]
    public sealed class Int64Extension : IMarkupExtension
    {
        public long Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) => Value;
    }
}
