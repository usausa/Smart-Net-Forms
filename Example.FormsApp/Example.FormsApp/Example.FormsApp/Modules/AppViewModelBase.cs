namespace Example.FormsApp.Modules
{
    using System.Threading.Tasks;

    using Smart.Forms.ViewModels;
    using Smart.Navigation;

    public class AppViewModelBase : ViewModelBase, INavigatorAware, INavigationEventSupport, INotifySupportAsync<ShellKeys>
    {
        public INavigator Navigator { get; set; }

        protected ApplicationState ApplicationState { get; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine($"{GetType()} is Disposed");
        }

        public AppViewModelBase(ApplicationState applicationState)
            : base(applicationState)
        {
            ApplicationState = applicationState;
        }

        public virtual void OnNavigatingFrom(INavigationContext context)
        {
        }

        public virtual void OnNavigatingTo(INavigationContext context)
        {
        }

        public virtual void OnNavigatedTo(INavigationContext context)
        {
        }

        public Task NavigatorNotifyAsync(ShellKeys parameter)
        {
            switch (parameter)
            {
                case ShellKeys.Back:
                    return OnNotifyBackAsync();
                case ShellKeys.Option:
                    return OnNotifyOptionAsync();
                case ShellKeys.Function1:
                    return OnNotifyFunction1Async();
                case ShellKeys.Function2:
                    return OnNotifyFunction2Async();
                case ShellKeys.Function3:
                    return OnNotifyFunction3Async();
                case ShellKeys.Function4:
                    return OnNotifyFunction4Async();
                default:
                    return Task.CompletedTask;
            }
        }

        protected virtual Task OnNotifyBackAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnNotifyOptionAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnNotifyFunction1Async()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnNotifyFunction2Async()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnNotifyFunction3Async()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnNotifyFunction4Async()
        {
            return Task.CompletedTask;
        }
    }
}
