namespace Smart.Forms.Components
{
    using System.Threading.Tasks;

    /// <summary>
    ///
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="acceptButton"></param>
        /// <param name="cancelButton"></param>
        /// <returns></returns>
        Task<bool> DisplayAlert(string title, string message, string acceptButton, string cancelButton);

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="cancelButton"></param>
        /// <returns></returns>
        Task DisplayAlert(string title, string message, string cancelButton);

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="cancelButton"></param>
        /// <param name="destroyButton"></param>
        /// <param name="otherButtons"></param>
        /// <returns></returns>
        Task<string> DisplayActionSheet(string title, string cancelButton, string destroyButton, params string[] otherButtons);

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        Task DisplayActionSheet(string title, params ActionSheetButton[] buttons);
    }
}