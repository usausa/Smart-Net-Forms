namespace Example.FormsApp.Modules.Interactivity
{
    using System.Threading.Tasks;

    using Smart.Forms.Input;
    using Smart.Navigation;

    public class InteractivityMenuViewModel : AppViewModelBase
    {
        public AsyncCommand<ViewId> ForwardCommand { get; }

        public InteractivityMenuViewModel(ApplicationState applicationState)
            : base(applicationState)
        {
            ForwardCommand = MakeAsyncCommand<ViewId>(x => Navigator.ForwardAsync(x));
        }

        protected override Task OnNotifyBackAsync()
        {
            return Navigator.ForwardAsync(ViewId.Menu);
        }
    }
}
