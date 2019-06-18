namespace Smart.Forms.Input
{
    using System;
    using System.Collections.Generic;

    using Smart.ComponentModel;
    using Smart.Forms.Internal;

    public static class ObserverCommandExtensions
    {
        public static TCommand Observe<TCommand, TValue>(this TCommand command, NotificationValue<TValue> value)
            where TCommand : ObserveCommandBase<TCommand>
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return command.Observe(value, nameof(value.Value));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "Ignore")]
        public static TCommand RemoveObserverBy<TCommand>(this TCommand command, ICollection<IDisposable> disposables)
            where TCommand : ObserveCommandBase<TCommand>
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (disposables is null)
            {
                throw new ArgumentNullException(nameof(disposables));
            }

            disposables.Add(new DelegateDisposable(() => command.RemoveObserver()));

            return command;
        }
    }
}
