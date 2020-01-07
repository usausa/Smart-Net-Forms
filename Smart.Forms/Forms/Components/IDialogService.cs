namespace Smart.Forms.Components
{
    using System.Threading.Tasks;

    public interface IDialogService
    {
        ValueTask<bool> DisplayAlert(string title, string message, string acceptButton, string cancelButton);

        ValueTask DisplayAlert(string title, string message, string cancelButton);

        ValueTask<string> DisplayActionSheet(string title, string cancelButton, string destroyButton, params string[] otherButtons);

        ValueTask DisplayActionSheet(string title, params ActionSheetButton[] buttons);
    }
}