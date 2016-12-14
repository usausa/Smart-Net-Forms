namespace Smart.Forms.Input
{
    using System;
    using System.Reflection;
    using System.Windows.Input;

    /// <summary>
    ///
    /// </summary>
    public sealed class DelegateCommand : ICommand
    {
        /// <summary>
        ///
        /// </summary>
        public event EventHandler CanExecuteChanged;

        private readonly Action execute;

        private readonly Func<bool> canExecute;

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action execute)
            : this(execute, () => true)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            execute();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return canExecute();
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
    public sealed class DelegateCommand<T> : ICommand
    {
        /// <summary>
        ///
        /// </summary>
        public event EventHandler CanExecuteChanged;

        private static readonly bool IsValueType = typeof(T).GetTypeInfo().IsValueType;

        private readonly Action<T> execute;

        private readonly Func<T, bool> canExecute;

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action<T> execute)
            : this(execute, x => true)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        void ICommand.Execute(object parameter)
        {
            execute(Cast(parameter));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool ICommand.CanExecute(object parameter)
        {
            return canExecute(Cast(parameter));
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