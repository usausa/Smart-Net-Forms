namespace Smart.Forms.Components
{
    using System.Threading.Tasks;

    public interface IDialogService
    {
        Task<bool> DisplayAlert(string title, string message, string acceptButton, string cancelButton);

        Task DisplayAlert(string title, string message, string cancelButton);

        Task<string> DisplayActionSheet(string title, string cancelButton, string destroyButton, params string[] otherButtons);

        Task DisplayActionSheet(string title, params ActionSheetButton[] buttons);
    }
}