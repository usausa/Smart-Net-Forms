namespace Smart.Forms.Messaging
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class SetLabelTextMessageAction : MessageAction<Label>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void Invoke(Label associatedObject, object parameter)
        {
            associatedObject.Text = parameter.ToString();
        }
    }
}
