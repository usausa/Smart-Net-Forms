namespace Smart.Forms.Markup
{
    using System;

    using Smart.Forms.Data;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public sealed class BoolToTextExtension : IMarkupExtension<BoolToObjectConverter<string>>
    {
        public string True { get; set; } = string.Empty;

        public string False { get; set; } = string.Empty;

        public BoolToObjectConverter<string> ProvideValue(IServiceProvider serviceProvider) =>
            new() { TrueValue = True, FalseValue = False };

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public sealed class BoolToColorExtension : IMarkupExtension<BoolToObjectConverter<Color>>
    {
        public Color True { get; set; }

        public Color False { get; set; }

        public BoolToObjectConverter<Color> ProvideValue(IServiceProvider serviceProvider) =>
            new() { TrueValue = True, FalseValue = False };

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
