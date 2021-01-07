namespace Smart.Forms.Markup
{
    using System;

    using Smart.Forms.Data;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public sealed class BooleanToColorConverterExtension : IMarkupExtension<BooleanToObjectConverter<Color>>
    {
        public Color True { get; set; }

        public Color False { get; set; }

        public BooleanToObjectConverter<Color> ProvideValue(IServiceProvider serviceProvider)
        {
            return new() { TrueValue = True, FalseValue = False };
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
