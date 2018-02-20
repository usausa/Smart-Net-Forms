namespace Smart.Forms.Animations
{
    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class BeginAnimationHandler : ActionHandler<VisualElement>
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

        protected override async void Invoke(VisualElement associatedObject, object parameter)
        {
            if (Animation != null)
            {
                if (Animation.Target == null)
                {
                    Animation.Target = associatedObject;
                }

                await Animation.Begin();
            }
        }
    }
}
