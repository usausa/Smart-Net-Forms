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
        public Messenger Messenger => messenger ?? (messenger = new Messenger());

        /// <summary>
        ///
        /// </summary>
        protected ViewModelBase()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="messenger"></param>
        protected ViewModelBase(Messenger messenger)
        {
            this.messenger = messenger;
        }
    }
}
