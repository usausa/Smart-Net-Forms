namespace Smart.Forms.Interactivity
{
    using System.Collections.Generic;
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ContentProperty("Actions")]
    public abstract class TriggerBehaviorBase<T> : BehaviorBase<T>
        where T : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        public IList<ITriggerAction> Actions { get; } = new List<ITriggerAction>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        protected void InvokeActions(object parameter)
        {
            foreach (var action in Actions)
            {
                action.Invoke(AssociatedObject, parameter);
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
