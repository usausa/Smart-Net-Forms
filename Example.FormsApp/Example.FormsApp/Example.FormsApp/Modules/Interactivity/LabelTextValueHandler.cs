namespace Example.FormsApp.Modules.Interactivity
{
    using Smart.Forms.Interactivity;
    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    public sealed class LabelTextValueHandler : ActionHandler<Label, ValueHolderEventArgs>
    {
        protected override void Invoke(Label associatedObject, ValueHolderEventArgs parameter)
        {
            parameter.Value = associatedObject.Text;
        }
    }
}
