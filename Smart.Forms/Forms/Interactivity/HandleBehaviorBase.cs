namespace Smart.Forms.Interactivity
{
    using System.Collections.Generic;
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [ContentProperty("Handlers")]
    public abstract class HandleBehaviorBase<T> : BehaviorBase<T>
        where T : BindableObject
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
                handler.Invoke(AssociatedObject, parameter);
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
