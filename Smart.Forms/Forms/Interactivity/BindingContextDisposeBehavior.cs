namespace Smart.Forms.Interactivity
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class BindingContextDisposeBehavior : BehaviorBase<NavigationPage>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(NavigationPage bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Popped += OnPopped;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(NavigationPage bindable)
        {
            bindable.Popped -= OnPopped;

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPopped(object sender, NavigationEventArgs e)
        {
            (e.Page.BindingContext as IDisposable)?.Dispose();
        }
    }
}
