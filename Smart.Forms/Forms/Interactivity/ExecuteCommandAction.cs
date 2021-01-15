namespace Smart.Forms.Interactivity
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public sealed class ExecuteCommandAction : BindableObject, IAction
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ExecuteCommandAction));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(ExecuteCommandAction));

        public static readonly BindableProperty ConverterProperty = BindableProperty.Create(
            nameof(Converter),
            typeof(IValueConverter),
            typeof(ExecuteCommandAction));

        public static readonly BindableProperty ConverterParameterProperty = BindableProperty.Create(
            nameof(ConverterParameter),
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

        public IValueConverter Converter
        {
            get => (IValueConverter)GetValue(ConverterProperty);
            set => SetValue(ConverterProperty, value);
        }

        public object ConverterParameter
        {
            get => GetValue(ConverterParameterProperty);
            set => SetValue(ConverterParameterProperty, value);
        }

        public void DoInvoke(BindableObject associatedObject, object parameter)
        {
            var command = Command;
            if (command is null)
            {
                return;
            }

            var commandParameter = CommandParameter;
            var argument = (commandParameter is not null) || IsSet(CommandParameterProperty)
                ? commandParameter
                : Converter?.Convert(parameter, typeof(object), ConverterParameter, null) ?? parameter;
            if (command.CanExecute(argument))
            {
                command.Execute(argument);
            }
        }
    }
}
