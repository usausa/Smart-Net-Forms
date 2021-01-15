namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    public abstract class ActionBase<TBindable> : BindableObject, IAction
        where TBindable : BindableObject
    {
        void IAction.DoInvoke(BindableObject associatedObject, object parameter)
        {
            Invoke((TBindable)associatedObject, parameter);
        }

        protected abstract void Invoke(TBindable associatedObject, object parameter);
    }

    public abstract class ActionBase<TBindable, TParameter> : BindableObject, IAction
        where TBindable : BindableObject
    {
        void IAction.DoInvoke(BindableObject associatedObject, object parameter)
        {
            Invoke((TBindable)associatedObject, (TParameter)parameter);
        }

        protected abstract void Invoke(TBindable associatedObject, TParameter parameter);
    }
}
