namespace Smart.Forms.ViewModels
{
    using System.ComponentModel;

    public interface IBusyState : INotifyPropertyChanged
    {
        bool IsBusy { get; set; }
    }
}
