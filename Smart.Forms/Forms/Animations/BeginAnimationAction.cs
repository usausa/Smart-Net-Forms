namespace Smart.Forms.Animations
{
    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    [ContentProperty("Animation")]
    public sealed class BeginAnimationAction : ActionBase<VisualElement>
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
        protected override async void Invoke(VisualElement associatedObject, object parameter)
        {
            if (Animation != null)
            {
                Animation.Target ??= associatedObject;

                await Animation.Begin();
            }
        }
    }
}
