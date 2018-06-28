namespace Example.FormsApp.Modules.Interactivity
{
    using Smart.Forms.Interactivity;
    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    public sealed class ResolveLabelTextHandler : IActionHandler
    {
        public void Invoke(object associatedObject, object parameter)
        {
            var label = (Label)associatedObject;
            var args = (ValueHolderEventArgs)parameter;

            args.Value = label.Text;
        }
    }
}
