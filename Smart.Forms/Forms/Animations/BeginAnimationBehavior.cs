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

        protected override async void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);

            if (Animation != null)
            {
                if (Animation.Target == null)
                {
                    Animation.Target = AssociatedObject;
                }

                var delay = Task.Delay(250);
                await Task.WhenAll(delay);
                await Animation.Begin();
            }
        }
    }
}