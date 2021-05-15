namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    public interface IAction
    {
        void DoInvoke(BindableObject associatedObject, object? parameter);
    }
}
