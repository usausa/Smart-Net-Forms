namespace Smart.Forms.Animations
{
    using System.Threading.Tasks;

    using Xamarin.Forms;

    public abstract class AnimationBase : BindableObject
    {
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(AnimationBase),
            null,
            BindingMode.TwoWay);

        public static readonly BindableProperty DelayProperty = BindableProperty.Create(
            nameof(Delay),
            typeof(int),
            typeof(AnimationBase),
            0,
            BindingMode.TwoWay);

        public static readonly BindableProperty DurationProperty = BindableProperty.Create(
            nameof(Duration),
            typeof(string),
            typeof(AnimationBase),
            "1000",
            BindingMode.TwoWay);

        public static readonly BindableProperty EasingProperty = BindableProperty.Create(
            nameof(Easing),
            typeof(EasingType),
            typeof(AnimationBase),
            EasingType.Linear,
            BindingMode.TwoWay);

        public VisualElement Target
        {
            get => (VisualElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        public int Delay
        {
            get => (int)GetValue(DelayProperty);
            set => SetValue(DelayProperty, value);
        }

        public string Duration
        {
            get => (string)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }

        public EasingType Easing
        {
            get => (EasingType)GetValue(EasingProperty);
            set => SetValue(EasingProperty, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2007:DoNotDirectlyAwaitATask", Justification = "Ignore")]
        public async Task Begin()
        {
            if (Delay > 0)
            {
                await Task.Delay(Delay);
            }

            await BeginAnimation();
        }

        protected abstract Task BeginAnimation();
    }
}