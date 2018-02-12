namespace Smart.Forms.Interactivity
{
    using System.ComponentModel;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class CancelEventHandleAction : TriggerAction<BindableObject>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty CancelProperty = BindableProperty.Create(
            nameof(Cancel),
            typeof(bool),
            typeof(CancelEventHandleAction),
            false);

        /// <summary>
        ///
        /// </summary>
        public bool Cancel
        {
            get => (bool)GetValue(CancelProperty);
            set => SetValue(CancelProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        protected override void Invoke(BindableObject associatedObject, object parameter)
        {
            var args = (CancelEventArgs)parameter;
            args.Cancel = Cancel;
        }
    }
}
