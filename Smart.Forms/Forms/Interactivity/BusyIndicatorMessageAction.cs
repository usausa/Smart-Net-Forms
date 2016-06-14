namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class BusyIndicatorMessageAction : MessageAction<Page, BusyIndicatorParameter>
    {
        /// <summary>
        ///
        /// </summary>
        public BusyIndicatorMessageAction()
            : base(typeof(BusyIndicatorParameter))
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void Invoke(Page associatedObject, BusyIndicatorParameter parameter)
        {
            associatedObject.IsBusy = parameter.IsBusy;
        }
    }
}
