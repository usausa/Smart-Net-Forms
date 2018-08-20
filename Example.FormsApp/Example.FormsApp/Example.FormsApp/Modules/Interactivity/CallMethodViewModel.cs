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

        private void NoParameter()
        {
            dialogService.DisplayAlert(string.Empty, "NoParameter", "OK");
        }

        // TODO Async

        // TODO Parameter

        // TOODO Parameter Async
    }
}
