namespace Smart.Forms.Input
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    ///
    /// </summary>
    public sealed class AsyncCommand : ICommand
    {
        /// <summary>
        ///
        /// </summary>
        public event EventHandler CanExecuteChanged;

        private readonly Func<Task> execute;

        private readonly Func<bool> canExecute;

        private bool executing;

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        public AsyncCommand(Func<Task> execute)
            : this(execute, () => true)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public AsyncCommand(Func<Task> execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return !executing && canExecute();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            ExecuteAsync();
        }

        /// <summary>
        ///
        /// </summary>
        private async void ExecuteAsync()
        {
            executing = true;
            RaiseCanExecuteChanged();

            try
            {
                var task = execute();
                await task;
            }
            finally
            {
                executing = false;
                RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Ignore")]
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class AsyncCommand<T> : ICommand
    {
        private static readonly bool IsValueType = typeof(T).GetTypeInfo().IsValueType;

        /// <summary>
        ///
        /// </summary>
        public event EventHandler CanExecuteChanged;

        private readonly Func<T, Task> execute;

        private readonly Func<T, bool> canExecute;

        private bool executing;

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        public AsyncCommand(Func<T, Task> execute)
            : this(execute, x => true)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return !executing && canExecute(Cast(parameter));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            ExecuteAsync(Cast(parameter));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        private async void ExecuteAsync(T parameter)
        {
            executing = true;
            RaiseCanExecuteChanged();

            try
            {
                var task = execute(parameter);
                await task;
            }
            finally
            {
                executing = false;
                RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private static T Cast(object parameter)
        {
            if ((parameter == null) && IsValueType)
            {
                return default(T);
            }

            return (T)parameter;
        }

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Ignore")]
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
