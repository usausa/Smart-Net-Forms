namespace Smart.Forms.Interactivity;

using Xamarin.Forms;

public abstract class ActionBase<TBindable> : BindableObject, IAction
    where TBindable : BindableObject
{
#pragma warning disable CA1033
    void IAction.DoInvoke(BindableObject associatedObject, object? parameter)
    {
        Invoke((TBindable)associatedObject, parameter);
    }
#pragma warning restore CA1033

    protected abstract void Invoke(TBindable associatedObject, object? parameter);
}

public abstract class ActionBase<TBindable, TParameter> : BindableObject, IAction
    where TBindable : BindableObject
{
#pragma warning disable CA1033
    void IAction.DoInvoke(BindableObject associatedObject, object? parameter)
    {
        Invoke((TBindable)associatedObject, (TParameter)parameter!);
    }
#pragma warning restore CA1033

    protected abstract void Invoke(TBindable associatedObject, TParameter parameter);
}
