namespace Smart.Forms.Interactivity
{
    using System.Collections.Generic;
    using Xamarin.Forms;

    [ContentProperty("Actions")]
    public abstract class TriggerBase<TBindable> : BehaviorBase<TBindable>
        where TBindable : BindableObject
    {
        public IList<IAction> Actions { get; } = new List<IAction>();

        protected void InvokeActions(object parameter)
        {
            foreach (var action in Actions)
            {
                action.DoInvoke(AssociatedObject, parameter);
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            foreach (var action in Actions)
            {
                if (action is BindableObject bindable)
                {
                    bindable.BindingContext = BindingContext;
                }
            }
        }
    }
}
