namespace Smart.Forms.Input;

using System.Reflection;
using System.Windows.Input;

using Smart.Forms.Internal;

public sealed class AsyncCommand : ObserveCommandBase<AsyncCommand>, ICommand, IDisposable
{
    private readonly Func<Task> execute;

    private readonly Func<bool> canExecute;

    public AsyncCommand(Func<Task> execute)
        : this(execute, Functions.True)
    {
    }

    public AsyncCommand(Func<Task> execute, Func<bool> canExecute)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public void Dispose() => RemoveObservers();

    bool ICommand.CanExecute(object? parameter) => canExecute();

    async void ICommand.Execute(object? parameter) => await execute();
}

public sealed class AsyncCommand<T> : ObserveCommandBase<AsyncCommand<T>>, ICommand, IDisposable
{
    private static readonly bool IsValueType = typeof(T).GetTypeInfo().IsValueType;

    private readonly Func<T, Task> execute;

    private readonly Func<T, bool> canExecute;

    public AsyncCommand(Func<T, Task> execute)
        : this(execute, Functions<T>.True)
    {
    }

    public AsyncCommand(Func<T, Task> execute, Func<T, bool> canExecute)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public void Dispose() => RemoveObservers();

    bool ICommand.CanExecute(object? parameter) => canExecute(Cast(parameter));

    async void ICommand.Execute(object? parameter) => await execute(Cast(parameter));

    private static T Cast(object? parameter)
    {
        if ((parameter is null) && IsValueType)
        {
            return default!;
        }

        return (T)parameter!;
    }
}
