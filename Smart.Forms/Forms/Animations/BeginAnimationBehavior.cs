namespace Smart.Forms.Animations
{
    using System.Threading.Tasks;

    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    [ContentProperty("Animation")]
    public sealed class BeginAnimationBehavior : BehaviorBase<VisualElement>
    {
        public static readonly BindableProperty AnimationProperty = BindableProperty.Create(
            nameof(Animation),
            typeof(AnimationBase),
            typeof(BeginAnimationBehavior));

        public AnimationBase Animation
        {
            get => (AnimationBase)GetValue(AnimationProperty);
            set => SetValue(AnimationProperty, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2007:DoNotDirectlyAwaitATask", Justification = "Ignore")]
        protected override async void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);

            if (Animation is not null)
            {
                Animation.Target ??= AssociatedObject;

                var delay = Task.Delay(250);
                await Task.WhenAll(delay);
                await Animation.Begin();
            }
        }
    }
}