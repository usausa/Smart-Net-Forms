namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TBindable"></typeparam>
    public abstract class ActionBase<TBindable> : BindableObject, IAction
        where TBindable : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        void IAction.DoInvoke(BindableObject associatedObject, object parameter)
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
    public abstract class ActionBase<TBindable, TParameter> : BindableObject, IAction
        where TBindable : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        void IAction.DoInvoke(BindableObject associatedObject, object parameter)
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
