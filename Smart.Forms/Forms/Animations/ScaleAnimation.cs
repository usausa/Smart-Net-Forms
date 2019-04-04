namespace Smart.Forms.Animations
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    public sealed class ScaleToAnimation : AnimationBase
    {
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create(
            nameof(Scale),
            typeof(double),
            typeof(ScaleToAnimation),
            0.0d,
            BindingMode.TwoWay);

        public double Scale
        {
            get => (double)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }

        protected override Task BeginAnimation()
        {
            return Target.ScaleTo(Scale, Convert.ToUInt32(Duration, CultureInfo.InvariantCulture), EasingHelper.GetEasing(Easing));
        }
    }

    public sealed class RelScaleToAnimation : AnimationBase
    {
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create(
            nameof(Scale),
            typeof(double),
            typeof(RelScaleToAnimation),
            0.0d,
            BindingMode.TwoWay);

        public double Scale
        {
            get => (double)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }

        protected override Task BeginAnimation()
        {
            return Target.RelScaleTo(Scale, Convert.ToUInt32(Duration, CultureInfo.InvariantCulture), EasingHelper.GetEasing(Easing));
        }
    }
}
