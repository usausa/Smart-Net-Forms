namespace Smart.Forms.Markup;

using System;

using Smart.Forms.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

public sealed class ColorBlendExtension : IMarkupExtension<ColorBlendConverter>
{
    public Color Color { get; set; }

    public double Raito { get; set; }

    public ColorBlendConverter ProvideValue(IServiceProvider serviceProvider) =>
        new() { Color = Color, Raito = Raito };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
