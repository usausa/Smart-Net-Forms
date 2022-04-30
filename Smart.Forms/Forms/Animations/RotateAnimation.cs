namespace Smart.Forms.Animations;

using System.Globalization;

using Xamarin.Forms;

public sealed class RotateToAnimation : AnimationBase
{
    public static readonly BindableProperty RotationProperty = BindableProperty.Create(
        nameof(Rotation),
        typeof(double),
        typeof(RotateToAnimation),
        0.0d,
        BindingMode.TwoWay);

    public double Rotation
    {
        get => (double)GetValue(RotationProperty);
        set => SetValue(RotationProperty, value);
    }

    protected override Task BeginAnimation()
    {
        return Target.RotateTo(Rotation, Convert.ToUInt32(Duration, CultureInfo.InvariantCulture), EasingHelper.GetEasing(Easing));
    }
}

public sealed class RelRotateToAnimation : AnimationBase
{
    public static readonly BindableProperty RotationProperty = BindableProperty.Create(
        nameof(Rotation),
        typeof(double),
        typeof(RelRotateToAnimation),
        0.0d,
        BindingMode.TwoWay);

    public double Rotation
    {
        get => (double)GetValue(RotationProperty);
        set => SetValue(RotationProperty, value);
    }

    protected override Task BeginAnimation()
    {
        return Target.RelRotateTo(Rotation, Convert.ToUInt32(Duration, CultureInfo.InvariantCulture), EasingHelper.GetEasing(Easing));
    }
}

public sealed class RotateXToAnimation : AnimationBase
{
    public static readonly BindableProperty RotationProperty = BindableProperty.Create(
        nameof(Rotation),
        typeof(double),
        typeof(RotateXToAnimation),
        0.0d,
        BindingMode.TwoWay);

    public double Rotation
    {
        get => (double)GetValue(RotationProperty);
        set => SetValue(RotationProperty, value);
    }

    protected override Task BeginAnimation()
    {
        return Target.RotateXTo(Rotation, Convert.ToUInt32(Duration, CultureInfo.InvariantCulture), EasingHelper.GetEasing(Easing));
    }
}

public sealed class RotateYToAnimation : AnimationBase
{
    public static readonly BindableProperty RotationProperty = BindableProperty.Create(
        nameof(Rotation),
        typeof(double),
        typeof(RotateYToAnimation),
        0.0d,
        BindingMode.TwoWay);

    public double Rotation
    {
        get => (double)GetValue(RotationProperty);
        set => SetValue(RotationProperty, value);
    }

    protected override Task BeginAnimation()
    {
        return Target.RotateYTo(Rotation, Convert.ToUInt32(Duration, CultureInfo.InvariantCulture), EasingHelper.GetEasing(Easing));
    }
}
