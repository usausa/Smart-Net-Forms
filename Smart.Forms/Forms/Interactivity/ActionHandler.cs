namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public interface IActionHandler
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        void DoInvoke(BindableObject associatedObject, object parameter);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TBindable"></typeparam>
    public abstract class ActionHandler<TBindable> : BindableObject, IActionHandler
        where TBindable : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        void IActionHandler.DoInvoke(BindableObject associatedObject, object parameter)
        {
            Invoke((TBindable)associatedObject, parameter);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        protected abstract void Invoke(TBindable associatedObject, object parameter);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TBindable"></typeparam>
    /// <typeparam name="TParameter"></typeparam>
    public abstract class ActionHandler<TBindable, TParameter> : BindableObject, IActionHandler
        where TBindable : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        void IActionHandler.DoInvoke(BindableObject associatedObject, object parameter)
        {
            Invoke((TBindable)associatedObject, (TParameter)parameter);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        protected abstract void Invoke(TBindable associatedObject, TParameter parameter);
    }
}
