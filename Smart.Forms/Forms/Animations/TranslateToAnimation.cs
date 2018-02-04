namespace Smart.Forms.Animations
{
    using System;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    public class TranslateToAnimation : AnimationBase
    {
        public static readonly BindableProperty TranslateXProperty = BindableProperty.Create(
            nameof(TranslateX),
            typeof(double),
            typeof(TranslateToAnimation),
            0.0d,
            propertyChanged: (bindable, oldValue, newValue) => ((TranslateToAnimation)bindable).TranslateX = (double)newValue);

        public static readonly BindableProperty TranslateYProperty = BindableProperty.Create(
            nameof(TranslateY),
            typeof(double),
            typeof(TranslateToAnimation),
            0.0d,
            propertyChanged: (bindable, oldValue, newValue) => ((TranslateToAnimation)bindable).TranslateY = (double)newValue);

        public double TranslateX
        {
            get => (double)GetValue(TranslateXProperty);
            set => SetValue(TranslateXProperty, value);
        }

        public double TranslateY
        {
            get => (double)GetValue(TranslateYProperty);
            set => SetValue(TranslateYProperty, value);
        }

        protected override Task BeginAnimation()
        {
            return Target.TranslateTo(TranslateX, TranslateY, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
        }
    }
}
