namespace Smart.Forms.Components
{
    using System.Linq;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class DialogService : IDialogService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="acceptButton"></param>
        /// <param name="cancelButton"></param>
        /// <returns></returns>
        public async Task<bool> DisplayAlert(string title, string message, string acceptButton, string cancelButton)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, acceptButton, cancelButton);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="cancelButton"></param>
        /// <returns></returns>
        public async Task DisplayAlert(string title, string message, string cancelButton)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancelButton);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="cancelButton"></param>
        /// <param name="destroyButton"></param>
        /// <param name="otherButtons"></param>
        /// <returns></returns>
        public async Task<string> DisplayActionSheet(string title, string cancelButton, string destroyButton, params string[] otherButtons)
        {
            return await Application.Current.MainPage.DisplayActionSheet(title, cancelButton, destroyButton, otherButtons);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public async Task DisplayActionSheet(string title, params ActionSheetButton[] buttons)
        {
            var cancelButton = buttons.FirstOrDefault(b => b.ButtonType == ActionSheetButtonType.Camcel);
            var destroyButton = buttons.FirstOrDefault(b => b.ButtonType == ActionSheetButtonType.Destroy);
            var otherButtonTexts = buttons.Where(b => b.ButtonType == ActionSheetButtonType.Other).Select(b => b.Text).ToArray();

            var selectedText = await DisplayActionSheet(title, cancelButton?.Text, destroyButton?.Text, otherButtonTexts);

            var selectedButton = buttons.FirstOrDefault(b => b.Text == selectedText);
            if ((selectedButton != null) && selectedButton.Command.CanExecute(selectedText))
            {
                selectedButton.Command.Execute(selectedText);
            }
        }
    }
}
