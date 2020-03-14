namespace Smart.Forms.ViewModels
{
    using Smart.ComponentModel;

    public class BusyState : NotificationObject, IBusyState
    {
        private int counter;

        public bool IsBusy
        {
            get => counter > 0;
        }

        public void Require()
        {
            counter++;
            RaisePropertyChanged(nameof(IsBusy));
        }

        public void Release()
        {
            counter--;
            RaisePropertyChanged(nameof(IsBusy));
        }

        public void Reset()
        {
            counter = 0;
            RaisePropertyChanged(nameof(IsBusy));
        }
    }
}
