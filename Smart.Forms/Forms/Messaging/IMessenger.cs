namespace Smart.Forms.Messaging
{
    /// <summary>
    ///
    /// </summary>
    public interface IMessenger
    {
        void Send(object message, object parameter);
    }
}
