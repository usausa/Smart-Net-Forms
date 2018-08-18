namespace Smart.Forms.Interactivity
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public sealed class ExecuteCommandAction : BindableObject, IAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ExecuteCommandAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(ExecuteCommandAction));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public void DoInvoke(BindableObject associatedObject, object parameter)
        {
            if (Command == null)
            {
                return;
            }

            var commandParameter = CommandParameter ?? parameter;
            if (Command.CanExecute(commandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }
    }
}
