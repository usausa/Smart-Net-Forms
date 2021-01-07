namespace Smart.Forms.Markup
{
    using System;

    using Smart.Forms.Data;

    using Xamarin.Forms.Xaml;

    public sealed class BooleanToTextConverterExtension : IMarkupExtension<BooleanToObjectConverter<string>>
    {
        public string True { get; set; }

        public string False { get; set; }

        public BooleanToObjectConverter<string> ProvideValue(IServiceProvider serviceProvider)
        {
            return new() { TrueValue = True, FalseValue = False };
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
