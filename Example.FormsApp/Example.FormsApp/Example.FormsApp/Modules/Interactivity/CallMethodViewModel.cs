namespace Example.FormsApp.Modules.Interactivity
{
    using System.Threading.Tasks;

    using Smart.Forms.Components;
    using Smart.Forms.Input;
    using Smart.Navigation;

    public class CallMethodViewModel : AppViewModelBase
    {
        private readonly IDialogService dialogService;

        public AsyncCommand<ViewId> ForwardCommand { get; }

        public CallMethodViewModel(
            ApplicationState applicationState,
            IDialogService dialogService)
            : base(applicationState)
        {
            this.dialogService = dialogService;

            ForwardCommand = MakeAsyncCommand<ViewId>(x => Navigator.ForwardAsync(x));
        }

        protected override Task OnNotifyBackAsync()
        {
            return Navigator.ForwardAsync(ViewId.InteractivityMenu);
        }

        public void NoParameter()
        {
            dialogService.DisplayAlert(string.Empty, "NoParameter", "OK");
        }

        public void WithParameter(string parameter)
        {
            dialogService.DisplayAlert(string.Empty, $"WithParameter ({parameter})", "OK");
        }

        public async Task NoParameterAsync()
        {
            await dialogService.DisplayAlert(string.Empty, "NoParameter", "OK");
        }

        public async Task WithParameterAsync(string parameter)
        {
            await dialogService.DisplayAlert(string.Empty, $"WithParameter ({parameter})", "OK");
        }
    }
}
