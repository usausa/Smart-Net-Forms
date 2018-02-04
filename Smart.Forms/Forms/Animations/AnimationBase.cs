namespace Smart.Forms.Animations
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    public abstract class AnimationBase : BindableObject
    {
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(AnimationBase),
            null,
            propertyChanged: (bindable, oldValue, newValue) => ((AnimationBase)bindable).Target = (VisualElement)newValue);

        public static readonly BindableProperty DelayProperty = BindableProperty.Create(
            nameof(Delay),
            typeof(int),
            typeof(AnimationBase),
            0,
            propertyChanged: (bindable, oldValue, newValue) => ((AnimationBase)bindable).Delay = (int)newValue);

        public static readonly BindableProperty DurationProperty = BindableProperty.Create(
            nameof(Duration),
            typeof(string),
            typeof(AnimationBase),
            "1000",
            propertyChanged: (bindable, oldValue, newValue) => ((AnimationBase)bindable).Duration = (string)newValue);

        public static readonly BindableProperty EasingProperty = BindableProperty.Create(
            nameof(Easing),
            typeof(EasingType),
            typeof(AnimationBase),
            EasingType.Linear,
            propertyChanged: (bindable, oldValue, newValue) => ((AnimationBase)bindable).Easing = (EasingType)newValue);

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

        private bool running;

        public async Task Begin()
        {
            try
            {
                if (!running)
                {
                    running = true;

                    await InternalBegin()
                        .ContinueWith(t => t.Exception, TaskContinuationOptions.OnlyOnFaulted)
                        .ConfigureAwait(false);
                }
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in animation {ex}");
            }
        }

        private async Task InternalBegin()
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