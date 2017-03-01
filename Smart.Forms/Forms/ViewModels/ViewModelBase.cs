namespace Smart.Forms.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Smart.ComponentModel;
    using Smart.Forms.Messaging;
    using Smart.Forms.Validation;

    /// <summary>
    ///
    /// </summary>
    public abstract class ViewModelBase : NotificationObject
    {
        private Messenger messenger;

        private Dictionary<string, List<IValidatable>> validationGroup;

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
        // Validation helper
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="validatables"></param>
        protected void RegisterValidation(params IValidatable[] validatables)
        {
            RegisterValidation(string.Empty, validatables);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="group"></param>
        /// <param name="validatables"></param>
        protected void RegisterValidation(string group, params IValidatable[] validatables)
        {
            if (validationGroup == null)
            {
                validationGroup = new Dictionary<string, List<IValidatable>>();
            }

            List<IValidatable> list;
            if (!validationGroup.TryGetValue(group, out list))
            {
                list = new List<IValidatable>();
                validationGroup[group] = list;
            }

            list.AddRange(validatables);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected bool Validate()
        {
            return Validate(string.Empty);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        protected bool Validate(string group)
        {
            var valid = true;

            List<IValidatable> list;
            if ((validationGroup != null) && validationGroup.TryGetValue(group, out list))
            {
                foreach (var validatable in list)
                {
                    if (!validatable.Validate())
                    {
                        valid = false;
                    }
                }
            }

            return valid;
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
