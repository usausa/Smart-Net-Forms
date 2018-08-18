namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    public class DefaultFocusBehavior : BehaviorBase<VisualElement>
    {
        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);

            Device.BeginInvokeOnMainThread(() => bindable.Focus());
        }
    }
}
