namespace Smart.Forms.ViewModels
{
    using System;
    using System.Threading.Tasks;

    using Smart.ComponentModel;
    using Smart.Forms.Messaging;

    /// <summary>
    ///
    /// </summary>
    public abstract class ViewModelBase : NotificationObject
    {
        private Messenger messenger;

        private bool isBusy;

        /// <summary>
        ///
        /// </summary>
        public Messenger Messenger => messenger ?? (messenger = new Messenger());

        /// <summary>
        ///
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

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

        // ------------------------------------------------------------
        // Execute helper
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public void ExecuteBusy(Action execute)
        {
            try
            {
                IsBusy = true;

                execute();
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public TResult ExecuteBusy<TResult>(Func<TResult> execute)
        {
            try
            {
                IsBusy = true;

                return execute();
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <returns></returns>
        public async Task ExecuteBusyAsync(Func<Task> execute)
        {
            try
            {
                IsBusy = true;

                await execute();
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute"></param>
        /// <returns></returns>
        public async Task<TResult> ExecuteBusyAsync<TResult>(Func<Task<TResult>> execute)
        {
            try
            {
                IsBusy = true;

                return await execute();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
