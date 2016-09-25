namespace Smart.Forms.ViewModels
{
    using Smart.ComponentModel;
    using Smart.Forms.Messaging;

    /// <summary>
    ///
    /// </summary>
    public abstract class ViewModelBase : NotificationObject
    {
        /// <summary>
        ///
        /// </summary>
        private Messenger messenger;

        /// <summary>
        ///
        /// </summary>
        public Messenger Messenger
        {
            get { return messenger ?? (messenger = new Messenger()); }
        }
    }
}
