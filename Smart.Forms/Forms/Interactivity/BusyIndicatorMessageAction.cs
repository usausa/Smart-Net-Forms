namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    using Xamarin.Forms;

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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:パブリック メソッドの引数の検証", Justification = "Ignore")]
        protected override void Invoke(Page associatedObject, BusyIndicatorParameter parameter)
        {
            associatedObject.IsBusy = parameter.IsBusy;
        }
    }
}
