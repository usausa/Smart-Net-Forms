namespace Smart.Forms.Interactivity
{
    using System.Collections.Generic;
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TBindable"></typeparam>
    [ContentProperty("Handlers")]
    public abstract class ActionBehaviorBase<TBindable> : BehaviorBase<TBindable>
        where TBindable : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        public IList<IActionHandler> Handlers { get; } = new List<IActionHandler>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        protected void InvokeActions(object parameter)
        {
            foreach (var handler in Handlers)
            {
                handler.DoInvoke(AssociatedObject, parameter);
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            foreach (var handler in Handlers)
            {
                if (handler is BindableObject bindable)
                {
                    bindable.BindingContext = BindingContext;
                }
            }
        }
    }
}
