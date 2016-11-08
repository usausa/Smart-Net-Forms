namespace Smart.Forms.Interactivity
{
    using System;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class DisplayAlertMessageAction : MessageAction<Page, DisplayAlertParameter>
    {
        /// <summary>
        ///
        /// </summary>
        public DisplayAlertMessageAction()
            : base(typeof(DisplayAlertParameter))
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void Invoke(Page associatedObject, DisplayAlertParameter parameter)
        {
            if (String.IsNullOrEmpty(parameter.Accept))
            {
                parameter.Result = associatedObject.DisplayAlert(parameter.Title, parameter.Message, parameter.Cancel)
                    .ContinueWith(t => false);
            }
            else
            {
                parameter.Result = associatedObject.DisplayAlert(parameter.Title, parameter.Message, parameter.Accept, parameter.Cancel);
            }
        }
    }
}
