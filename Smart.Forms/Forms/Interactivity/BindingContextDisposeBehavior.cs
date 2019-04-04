namespace Smart.Forms.Interactivity
{
    using System;

    using Xamarin.Forms;

    public sealed class BindingContextDisposeBehavior : BehaviorBase<NavigationPage>
    {
        protected override void OnAttachedTo(NavigationPage bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Popped += OnPopped;
        }

        protected override void OnDetachingFrom(NavigationPage bindable)
        {
            bindable.Popped -= OnPopped;

            base.OnDetachingFrom(bindable);
        }

        private void OnPopped(object sender, NavigationEventArgs e)
        {
            (e.Page.BindingContext as IDisposable)?.Dispose();
        }
    }
}
