namespace Smart.Forms.Animations
{
    using Xamarin.Forms;

    [ContentProperty("Animation")]
    public sealed class BeginAnimationAction : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            if (Animation != null)
            {
                await Animation.Begin();
            }
        }
    }
}
