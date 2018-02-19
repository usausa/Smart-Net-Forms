namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class SetFocusBehavior : BehaviorBase<VisualElement>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);

            Device.BeginInvokeOnMainThread(() => bindable.Focus());
        }
    }
}
