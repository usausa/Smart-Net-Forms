namespace Smart.Forms.Markup;

using System;

using Smart.Forms.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

public sealed class ContainsToBoolExtension : IMarkupExtension<ContainsConverter<bool>>
{
    public bool Invert { get; set; }

    public ContainsConverter<bool> ProvideValue(IServiceProvider serviceProvider) =>
        new() { TrueValue = !Invert, FalseValue = Invert };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}

public sealed class ContainsToTextExtension : IMarkupExtension<ContainsConverter<string>>
{
    public string True { get; set; } = string.Empty;

    public string False { get; set; } = string.Empty;

    public ContainsConverter<string> ProvideValue(IServiceProvider serviceProvider) =>
        new() { TrueValue = True, FalseValue = False };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}

public sealed class ContainsToColorExtension : IMarkupExtension<ContainsConverter<Color>>
{
    public Color True { get; set; }

    public Color False { get; set; }

    public ContainsConverter<Color> ProvideValue(IServiceProvider serviceProvider) =>
        new() { TrueValue = True, FalseValue = False };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
