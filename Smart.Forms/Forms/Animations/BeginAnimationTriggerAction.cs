namespace Smart.Forms.Animations
{
    using Xamarin.Forms;

    [ContentProperty("Animation")]
    public sealed class BeginAnimationTriggerAction : TriggerAction<VisualElement>
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
