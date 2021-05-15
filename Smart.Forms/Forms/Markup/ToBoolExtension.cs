namespace Smart.Forms.Markup
{
    using System;

    using Smart.Forms.Data;

    using Xamarin.Forms.Xaml;

    public sealed class TextToBoolExtension : IMarkupExtension<ObjectToBoolConverter<string>>
    {
        public string True { get; set; } = string.Empty;

        public string False { get; set; } = string.Empty;

        public ObjectToBoolConverter<string> ProvideValue(IServiceProvider serviceProvider) =>
            new() { TrueValue = True, FalseValue = False };

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public sealed class IntToBoolExtension : IMarkupExtension<ObjectToBoolConverter<int>>
    {
        public int True { get; set; }

        public int False { get; set; }

        public ObjectToBoolConverter<int> ProvideValue(IServiceProvider serviceProvider) =>
            new() { TrueValue = True, FalseValue = False };

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
