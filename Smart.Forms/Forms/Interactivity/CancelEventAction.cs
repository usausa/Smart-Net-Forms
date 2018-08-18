namespace Smart.Forms.Interactivity
{
    using System.ComponentModel;

    using Xamarin.Forms;

    public sealed class CancelEvent : ActionBase<BindableObject, CancelEventArgs>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty CancelProperty = BindableProperty.Create(
            nameof(Cancel),
            typeof(bool),
            typeof(CancelEvent),
            false);

        public bool Cancel
        {
            get => (bool)GetValue(CancelProperty);
            set => SetValue(CancelProperty, value);
        }

        protected override void Invoke(BindableObject associatedObject, CancelEventArgs parameter)
        {
            parameter.Cancel = Cancel;
        }
    }
}
