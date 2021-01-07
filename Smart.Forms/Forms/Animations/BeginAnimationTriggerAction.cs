namespace Smart.Forms.Animations
{
    using Xamarin.Forms;

    [ContentProperty("Animation")]
    public sealed class BeginAnimationTriggerAction : TriggerAction<VisualElement>
    {
        public AnimationBase Animation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2007:DoNotDirectlyAwaitATask", Justification = "Ignore")]
        protected override async void Invoke(VisualElement sender)
        {
            if (Animation is not null)
            {
                await Animation.Begin();
            }
        }
    }
}
