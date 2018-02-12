namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class SetFocusAction : TriggerAction<VisualElement>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void Invoke(VisualElement associatedObject, object parameter)
        {
            associatedObject.Focus();
        }
    }
}
