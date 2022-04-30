namespace Smart.Forms.Markup;

using Smart.Forms.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

public sealed class NullToBoolExtension : IMarkupExtension<NullToObjectConverter<bool>>
{
    public bool Invert { get; set; }

    public bool HandleEmptyString { get; set; }

    public NullToObjectConverter<bool> ProvideValue(IServiceProvider serviceProvider) =>
        new() { NullValue = !Invert, NonNullValue = Invert, HandleEmptyString = HandleEmptyString };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}

public sealed class NullToTextExtension : IMarkupExtension<NullToObjectConverter<string>>
{
    public string Null { get; set; } = string.Empty;

    public string NonNull { get; set; } = string.Empty;

    public bool HandleEmptyString { get; set; }

    public NullToObjectConverter<string> ProvideValue(IServiceProvider serviceProvider) =>
        new() { NullValue = Null, NonNullValue = NonNull, HandleEmptyString = HandleEmptyString };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}

public sealed class NullToColorExtension : IMarkupExtension<NullToObjectConverter<Color>>
{
    public Color Null { get; set; }

    public Color NonNull { get; set; }

    public bool HandleEmptyString { get; set; }

    public NullToObjectConverter<Color> ProvideValue(IServiceProvider serviceProvider) =>
        new() { NullValue = Null, NonNullValue = NonNull, HandleEmptyString = HandleEmptyString };

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
