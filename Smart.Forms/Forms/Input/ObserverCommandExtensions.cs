namespace Smart.Forms.Input
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Smart.Forms.Internal;

    public static class ObserverCommandExtensions
    {
        public static TCommand Observe<TCommand>(this TCommand command, params INotifyPropertyChanged[] values)
            where TCommand : ObserveCommandBase<TCommand>
        {
            foreach (var value in values)
            {
                command.Observe(value);
            }

            return command;
        }

        public static TCommand Observe<TCommand>(this TCommand command, IEnumerable<INotifyPropertyChanged> values)
            where TCommand : ObserveCommandBase<TCommand>
        {
            foreach (var value in values)
            {
                command.Observe(value);
            }

            return command;
        }
    }
}
