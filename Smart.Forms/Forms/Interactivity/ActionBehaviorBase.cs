namespace Smart.Forms.Interactivity
{
    using System.Collections.Generic;
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TBindable"></typeparam>
    [ContentProperty("Actions")]
    public abstract class ActionBehaviorBase<TBindable> : BehaviorBase<TBindable>
        where TBindable : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        public IList<IAction> Actions { get; } = new List<IAction>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        protected void InvokeActions(object parameter)
        {
            foreach (var action in Actions)
            {
                action.DoInvoke(AssociatedObject, parameter);
            }
        }

        /// <summary>
        ///
        /// </summary>
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
