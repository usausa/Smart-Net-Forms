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

    public abstract class ViewModelBase : NotificationObject, IDisposable
    {
        private ListDisposable disposables;

        private IBusyState busyState;

        private IMessenger messenger;

        private Dictionary<string, List<IValidatable>> validationGroup;

        // ------------------------------------------------------------
        // Disposables
        // ------------------------------------------------------------

        protected ICollection<IDisposable> Disposables => disposables ?? (disposables = new ListDisposable());

        // ------------------------------------------------------------
        // Busy
        // ------------------------------------------------------------

        public IBusyState BusyState => busyState ?? (busyState = new BusyState());

        // ------------------------------------------------------------
        // Messenger
        // ------------------------------------------------------------

        public IMessenger Messenger => messenger ?? (messenger = new Messenger());

        // ------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------

        protected ViewModelBase()
        {
        }

        protected ViewModelBase(IBusyState busyState)
        {
            this.busyState = busyState;
        }

        protected ViewModelBase(Messenger messenger)
        {
            this.messenger = messenger;
        }

        protected ViewModelBase(IBusyState busyState, IMessenger messenger)
        {
            this.busyState = busyState;
            this.messenger = messenger;
        }

        ~ViewModelBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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

        protected void RegisterValidation(params IValidatable[] validatables)
        {
            RegisterValidation(string.Empty, validatables);
        }

        protected void RegisterValidation(string group, params IValidatable[] validatables)
        {
            if (validationGroup is null)
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

        protected bool Validate()
        {
            return Validate(string.Empty);
        }

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

        protected Task ExecuteBusyAsync(Func<Task> execute)
        {
            return BusyHelper.ExecuteBusyAsync(BusyState, execute);
        }

        protected Task<TResult> ExecuteBusyAsync<TResult>(Func<Task<TResult>> execute)
        {
            return BusyHelper.ExecuteBusyAsync(BusyState, execute);
        }

        // ------------------------------------------------------------
        // DelegateCommand helper
        // ------------------------------------------------------------

        protected DelegateCommand MakeDelegateCommand(Action execute)
        {
            return MakeDelegateCommand(execute, Actions.True);
        }

        protected DelegateCommand MakeDelegateCommand(Action execute, Func<bool> canExecute)
        {
            return new DelegateCommand(execute, () => !BusyState.IsBusy && canExecute())
                .Observe(BusyState, nameof(IBusyState.IsBusy))
                .RemoveObserverBy(Disposables);
        }

        protected DelegateCommand<TParameter> MakeDelegateCommand<TParameter>(Action<TParameter> execute)
        {
            return MakeDelegateCommand(execute, Actions<TParameter>.True);
        }

        protected DelegateCommand<TParameter> MakeDelegateCommand<TParameter>(Action<TParameter> execute, Func<TParameter, bool> canExecute)
        {
            return new DelegateCommand<TParameter>(execute, x => !BusyState.IsBusy && canExecute(x))
                .Observe(BusyState, nameof(IBusyState.IsBusy))
                .RemoveObserverBy(Disposables);
        }

        // ------------------------------------------------------------
        // AsyncCommand helper
        // ------------------------------------------------------------

        protected AsyncCommand MakeAsyncCommand(Func<Task> execute)
        {
            return MakeAsyncCommand(execute, Actions.True);
        }

        protected AsyncCommand MakeAsyncCommand(Func<Task> execute, Func<bool> canExecute)
        {
            return new AsyncCommand(
                async () =>
                {
                    BusyState.IsBusy = true;
                    try
                    {
                        await execute();
                    }
                    finally
                    {
                        BusyState.IsBusy = false;
                    }
                }, () => !BusyState.IsBusy && canExecute())
                .Observe(BusyState, nameof(IBusyState.IsBusy))
                .RemoveObserverBy(Disposables);
        }

        protected AsyncCommand<TParameter> MakeAsyncCommand<TParameter>(Func<TParameter, Task> execute)
        {
            return MakeAsyncCommand(execute, Actions<TParameter>.True);
        }

        protected AsyncCommand<TParameter> MakeAsyncCommand<TParameter>(Func<TParameter, Task> execute, Func<TParameter, bool> canExecute)
        {
            return new AsyncCommand<TParameter>(
                async parameter =>
                {
                    BusyState.IsBusy = true;
                    try
                    {
                        await execute(parameter);
                    }
                    finally
                    {
                        BusyState.IsBusy = false;
                    }
                }, parameter => !BusyState.IsBusy && canExecute(parameter))
                .Observe(BusyState, nameof(IBusyState.IsBusy))
                .RemoveObserverBy(Disposables);
        }
    }
}
