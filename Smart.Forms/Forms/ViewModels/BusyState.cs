namespace Smart.Forms.ViewModels
{
    using Smart.ComponentModel;

    public class BusyState : NotificationObject, IBusyState
    {
        private bool isBusy;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }
    }
}
