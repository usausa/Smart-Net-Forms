namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TriggerAction<T> : BindableObject, ITriggerAction
        where T : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        public void Invoke(object associatedObject, object parameter)
        {
            Invoke((T)associatedObject, parameter);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        protected abstract void Invoke(T associatedObject, object parameter);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <typeparam name="TParameter"></typeparam>
    public abstract class TriggerAction<TObject, TParameter> : BindableObject, ITriggerAction
        where TObject : BindableObject
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        public void Invoke(object associatedObject, object parameter)
        {
            Invoke((TObject)associatedObject, (TParameter)parameter);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        protected abstract void Invoke(TObject associatedObject, TParameter parameter);
    }
}
