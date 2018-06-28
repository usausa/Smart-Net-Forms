namespace Example.FormsApp.Modules.Interactivity
{
    using System.Threading.Tasks;

    using Smart.Forms.Components;
    using Smart.Forms.Input;
    using Smart.Forms.Messaging;
    using Smart.Navigation;

    public class ResolveHandlerViewModel : AppViewModelBase
    {
        private readonly IDialogService dialogService;

        public ResolveInteractionRequest<string> ResolveLabelTextRequest { get; } = new ResolveInteractionRequest<string>();

        public AsyncCommand ResolveCommand { get; }

        public ResolveHandlerViewModel(
            ApplicationState applicationState,
            IDialogService dialogService)
            : base(applicationState)
        {
            this.dialogService = dialogService;

            ResolveCommand = MakeAsyncCommand(ResolveText);
        }

        protected override Task OnNotifyBackAsync()
        {
            return Navigator.ForwardAsync(ViewId.InteractivityMenu);
        }

        private Task ResolveText()
        {
            var text = ResolveLabelTextRequest.Resolve();

            return dialogService.DisplayAlert(string.Empty, text, "OK");
        }
    }
}
