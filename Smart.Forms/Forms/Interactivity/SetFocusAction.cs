namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class SetFocusAction : ActionBase<BindableObject>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(SetFocusAction));

        /// <summary>
        ///
        /// </summary>
        public VisualElement Target
        {
            get => (VisualElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        protected override void Invoke(BindableObject associatedObject, object parameter)
        {
            var element = Target ?? (associatedObject as VisualElement);
            element?.Focus();
        }
    }
}
