namespace Smart.Forms.Interactivity
{
    using System;

    using Xamarin.Forms;

    public sealed class BindingContextDisposeBehavior : BehaviorBase<NavigationPage>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(NavigationPage bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Popped += OnPopped;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(NavigationPage bindable)
        {
            bindable.Popped -= OnPopped;

            base.OnDetachingFrom(bindable);
        }

        private static void OnPopped(object sender, NavigationEventArgs e)
        {
            (e.Page.BindingContext as IDisposable)?.Dispose();
        }
    }
}
