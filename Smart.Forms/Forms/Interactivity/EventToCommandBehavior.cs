namespace Smart.Forms.Interactivity;

using System;
using System.Reflection;
using System.Windows.Input;

using Xamarin.Forms;

public sealed class EventToCommandBehavior : BehaviorBase<BindableObject>
{
    public static readonly BindableProperty EventNameProperty = BindableProperty.Create(
        nameof(EventName),
        typeof(string),
        typeof(EventToCommandBehavior),
        string.Empty,
        propertyChanged: HandleEventNamePropertyChanged);

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(EventToCommandBehavior));

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandParameter),
        typeof(object),
        typeof(EventToCommandBehavior));

    public static readonly BindableProperty ConverterProperty = BindableProperty.Create(
        nameof(Converter),
        typeof(IValueConverter),
        typeof(EventToCommandBehavior));

    public static readonly BindableProperty ConverterParameterProperty = BindableProperty.Create(
        nameof(ConverterParameter),
        typeof(object),
        typeof(EventToCommandBehavior));

    private EventInfo? eventInfo;

    private Delegate? handler;

    public string EventName
    {
        get => (string)GetValue(EventNameProperty);
        set => SetValue(EventNameProperty, value);
    }

    public ICommand? Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object? CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IValueConverter? Converter
    {
        get => (IValueConverter)GetValue(ConverterProperty);
        set => SetValue(ConverterProperty, value);
    }

    public object? ConverterParameter
    {
        get => GetValue(ConverterParameterProperty);
        set => SetValue(ConverterParameterProperty, value);
    }

    protected override void OnAttachedTo(BindableObject bindable)
    {
        base.OnAttachedTo(bindable);

        AddEventHandler(EventName);
    }

    protected override void OnDetachingFrom(BindableObject bindable)
    {
        RemoveEventHandler();

        base.OnDetachingFrom(bindable);
    }

    private void AddEventHandler(string eventName)
    {
        if (String.IsNullOrEmpty(eventName))
        {
            return;
        }

        eventInfo = AssociatedObject!.GetType().GetRuntimeEvent(EventName);
        if (eventInfo is null)
        {
            throw new ArgumentException(nameof(EventName));
        }

        var methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod(nameof(OnEvent));
        handler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
        eventInfo.AddEventHandler(AssociatedObject, handler);
    }

    private void RemoveEventHandler()
    {
        eventInfo?.RemoveEventHandler(AssociatedObject, handler);
        eventInfo = null;
        handler = null;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = "Ignore")]
    private void OnEvent(object sender, EventArgs e)
    {
        var command = Command;
        if (command is null)
        {
            return;
        }

        var commandParameter = CommandParameter;
        var parameter = (commandParameter is not null) || IsSet(CommandParameterProperty)
            ? commandParameter
            : Converter?.Convert(e, typeof(object), ConverterParameter, null) ?? e;
        if (command.CanExecute(parameter))
        {
            command.Execute(parameter);
        }
    }

    private static void HandleEventNamePropertyChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        var behavior = (EventToCommandBehavior)bindable;
        if (behavior.AssociatedObject is null)
        {
            return;
        }

        behavior.RemoveEventHandler();
        if (newValue is not null)
        {
            behavior.AddEventHandler((string)newValue);
        }
    }
}
