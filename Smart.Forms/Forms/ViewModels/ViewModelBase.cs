namespace Smart.Forms.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Smart.ComponentModel;
    using Smart.Forms.Input;
    using Smart.Forms.Internal;
    using Smart.Forms.Messaging;
    using Smart.Forms.Validation;

    /// <summary>
    ///
    /// </summary>
    public abstract class ViewModelBase : NotificationObject, IDisposable
    {
        private ListDisposable disposables;

        private IBusyState busyState;

        private IMessenger messenger;

        private Dictionary<string, List<IValidatable>> validationGroup;

        // ------------------------------------------------------------
        // Disposables
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        protected ICollection<IDisposable> Disposables => disposables ?? (disposables = new ListDisposable());

        // ------------------------------------------------------------
        // Busy
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        public IBusyState BusyState => busyState ?? (busyState = new BusyState());

        // ------------------------------------------------------------
        // Messenger
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        public IMessenger Messenger => messenger ?? (messenger = new Messenger());

        // ------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        protected ViewModelBase()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="busyState"></param>
        protected ViewModelBase(IBusyState busyState)
        {
            this.busyState = busyState;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="messenger"></param>
        protected ViewModelBase(Messenger messenger)
        {
            this.messenger = messenger;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="busyState"></param>
        /// <param name="messenger"></param>
        protected ViewModelBase(IBusyState busyState, IMessenger messenger)
        {
            this.busyState = busyState;
            this.messenger = messenger;
        }

        /// <summary>
        ///
        /// </summary>
        ~ViewModelBase()
        {
            Dispose(false);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                disposables?.Dispose();
            }
        }

        // ------------------------------------------------------------
        // Validation
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

            if (!validationGroup.TryGetValue(group, out var list))
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

            if ((validationGroup != null) && validationGroup.TryGetValue(group, out var list))
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
        /// <returns></returns>
        public Task ExecuteBusyAsync(Func<Task> execute)
        {
            return BusyHelper.ExecuteBusyAsync(busyState, execute);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="execute"></param>
        /// <returns></returns>
        public Task<TResult> ExecuteBusyAsync<TResult>(Func<Task<TResult>> execute)
        {
            return BusyHelper.ExecuteBusyAsync(busyState, execute);
        }

        // ------------------------------------------------------------
        // DelegateCommand helper
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <returns></returns>
        protected DelegateCommand MakeDelegateCommand(Action execute)
        {
            return MakeDelegateCommand(execute, Actions.True);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <returns></returns>
        protected DelegateCommand MakeDelegateCommand(Action execute, Func<bool> canExecute)
        {
            return new DelegateCommand(execute, canExecute)
                .RemoveObserverBy(Disposables);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="execute"></param>
        /// <returns></returns>
        protected DelegateCommand<TParameter> MakeDelegateCommand<TParameter>(Action<TParameter> execute)
        {
            return MakeDelegateCommand(execute, Actions<TParameter>.True);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <returns></returns>
        protected DelegateCommand<TParameter> MakeDelegateCommand<TParameter>(Action<TParameter> execute, Func<TParameter, bool> canExecute)
        {
            return new DelegateCommand<TParameter>(execute, canExecute)
                .RemoveObserverBy(Disposables);
        }

        // ------------------------------------------------------------
        // AsyncCommand helper
        // ------------------------------------------------------------

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <returns></returns>
        protected AsyncCommand MakeAsyncCommand(Func<Task> execute)
        {
            return MakeAsyncCommand(execute, Actions.True);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <returns></returns>
        protected AsyncCommand MakeAsyncCommand(Func<Task> execute, Func<bool> canExecute)
        {
            return new AsyncCommand(
                async () =>
                {
                    busyState.IsBusy = true;
                    try
                    {
                        await execute();
                    }
                    finally
                    {
                        busyState.IsBusy = false;
                    }
                }, () => !busyState.IsBusy && canExecute())
                .Observe(busyState, nameof(IBusyState.IsBusy))
                .RemoveObserverBy(Disposables);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="execute"></param>
        /// <returns></returns>
        protected AsyncCommand<TParameter> MakeAsyncCommand<TParameter>(Func<TParameter, Task> execute)
        {
            return MakeAsyncCommand(execute, Actions<TParameter>.True);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        /// <returns></returns>
        protected AsyncCommand<TParameter> MakeAsyncCommand<TParameter>(Func<TParameter, Task> execute, Func<TParameter, bool> canExecute)
        {
            return new AsyncCommand<TParameter>(
                async parameter =>
                {
                    busyState.IsBusy = true;
                    try
                    {
                        await execute(parameter);
                    }
                    finally
                    {
                        busyState.IsBusy = false;
                    }
                }, parameter => !busyState.IsBusy && canExecute(parameter))
                .Observe(busyState, nameof(IBusyState.IsBusy))
                .RemoveObserverBy(Disposables);
        }
    }
}
