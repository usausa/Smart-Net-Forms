namespace Smart.Forms.Animations
{
    using System;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    public enum FadeDirection
    {
        Up,
        Down
    }

    public class FadeToAnimation : AnimationBase
    {
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create(
            nameof(Opacity),
            typeof(double),
            typeof(FadeToAnimation),
            0.0d,
            BindingMode.TwoWay);

        public double Opacity
        {
            get => (double)GetValue(OpacityProperty);
            set => SetValue(OpacityProperty, value);
        }

        protected override Task BeginAnimation()
        {
            return Target.FadeTo(Opacity, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }

    public class FadeInAnimation : AnimationBase
    {
        public static readonly BindableProperty DirectionProperty = BindableProperty.Create(
            nameof(Direction),
            typeof(FadeDirection),
            typeof(FadeInAnimation),
            FadeDirection.Up,
            BindingMode.TwoWay);

        public FadeDirection Direction
        {
            get => (FadeDirection)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        protected override Task BeginAnimation()
        {
            return Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("FadeIn", FadeIn(), 16, Convert.ToUInt32(Duration));
                });
            });
        }

        private Animation FadeIn()
        {
            var animation = new Animation();
            animation.WithConcurrent(
                x => Target.Opacity = x,
                0,
                1,
                Xamarin.Forms.Easing.CubicOut);
            animation.WithConcurrent(
                x => Target.TranslationY = x,
                Target.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50),
                Target.TranslationY,
                Xamarin.Forms.Easing.CubicOut);
            return animation;
        }
    }

    public class FadeOutAnimation : AnimationBase
    {
        public static readonly BindableProperty DirectionProperty = BindableProperty.Create(
            nameof(Direction),
            typeof(FadeDirection),
            typeof(FadeOutAnimation),
            FadeDirection.Up,
            BindingMode.TwoWay);

        public FadeDirection Direction
        {
            get => (FadeDirection)GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }

        protected override Task BeginAnimation()
        {
            return Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Target.Animate("FadeOut", FadeOut(), 16, Convert.ToUInt32(Duration));
                });
            });
        }

        private Animation FadeOut()
        {
            var animation = new Animation();
            animation.WithConcurrent(
                x => Target.Opacity = x,
                1,
                0);
            animation.WithConcurrent(
                x => Target.TranslationY = x,
                Target.TranslationY,
                Target.TranslationY + ((Direction == FadeDirection.Up) ? 50 : -50));
            return animation;
        }
    }
}
