namespace Example.FormsApp.Modules.Interactivity
{
    using System.Threading.Tasks;

    using Smart.Forms.Components;
    using Smart.Forms.Input;
    using Smart.Forms.Messaging;
    using Smart.Navigation;

    public class ValueRequestViewModel : AppViewModelBase
    {
        private readonly IDialogService dialogService;

        public ValueRequest<string> LabelTextValueRequest { get; } = new ValueRequest<string>();

        public AsyncCommand ResolveCommand { get; }

        public ValueRequestViewModel(
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
            var text = LabelTextValueRequest.Resolve();

            return dialogService.DisplayAlert(string.Empty, text, "OK");
        }
    }
}
