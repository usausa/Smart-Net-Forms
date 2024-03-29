namespace Smart.Forms.Animations;

using System.Globalization;

using Xamarin.Forms;

public sealed class ColorAnimation : AnimationBase
{
    public static readonly BindableProperty ToColorProperty = BindableProperty.Create(
        nameof(ToColor),
        typeof(Color),
        typeof(ColorAnimation),
        Color.Default,
        BindingMode.TwoWay);

    public Color ToColor
    {
        get => (Color)GetValue(ToColorProperty);
        set => SetValue(ToColorProperty, value);
    }

    protected override Task BeginAnimation()
    {
        var fromColor = Target!.BackgroundColor;
        // ReSharper disable once AsyncVoidLambda
        return Task.Run(() => Device.BeginInvokeOnMainThread(async () =>
            await Target.ColorTo(fromColor, ToColor, c => Target.BackgroundColor = c, Convert.ToUInt32(Duration, CultureInfo.InvariantCulture))));
    }
}
