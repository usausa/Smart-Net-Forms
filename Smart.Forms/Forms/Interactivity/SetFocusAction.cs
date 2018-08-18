namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    public sealed class SetFocusAction : ActionBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(SetFocusAction));

        public VisualElement Target
        {
            get => (VisualElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        protected override void Invoke(BindableObject associatedObject, object parameter)
        {
            var element = Target ?? (associatedObject as VisualElement);
            element?.Focus();
        }
    }
}
