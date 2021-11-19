namespace Smart.Forms.Interactivity;

using System;
using System.Reflection;

using Xamarin.Forms;

public sealed class ChangePropertyAction : BindableObject, IAction
{
    public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
        nameof(TargetObject),
        typeof(object),
        typeof(ChangePropertyAction));

    public static readonly BindableProperty PropertyNameProperty = BindableProperty.Create(
        nameof(PropertyName),
        typeof(string),
        typeof(ChangePropertyAction),
        string.Empty);

    public static readonly BindableProperty ParameterProperty = BindableProperty.Create(
        nameof(Parameter),
        typeof(object),
        typeof(ChangePropertyAction));

    public static readonly BindableProperty ConverterProperty = BindableProperty.Create(
        nameof(Converter),
        typeof(IValueConverter),
        typeof(ChangePropertyAction));

    public static readonly BindableProperty ConverterParameterProperty = BindableProperty.Create(
        nameof(ConverterParameter),
        typeof(object),
        typeof(ChangePropertyAction));

    public object? TargetObject
    {
        get => GetValue(TargetObjectProperty);
        set => SetValue(TargetObjectProperty, value);
    }

    public string PropertyName
    {
        get => (string)GetValue(PropertyNameProperty);
        set => SetValue(PropertyNameProperty, value);
    }

    public object? Parameter
    {
        get => GetValue(ParameterProperty);
        set => SetValue(ParameterProperty, value);
    }

    public IValueConverter? Converter
    {
        get => (IValueConverter)GetValue(ConverterProperty);
        set => SetValue(ConverterProperty, value);
    }

    public object ConverterParameter
    {
        get => GetValue(ConverterParameterProperty);
        set => SetValue(ConverterParameterProperty, value);
    }

    private PropertyInfo? property;

    public void DoInvoke(BindableObject associatedObject, object? parameter)
    {
        var target = TargetObject ?? associatedObject;
        var propertyName = PropertyName;
        if (String.IsNullOrEmpty(propertyName))
        {
            return;
        }

        if ((property is null) ||
            (property.DeclaringType != target.GetType()) ||
            (property.Name != propertyName))
        {
            property = target.GetType().GetRuntimeProperty(propertyName);
        }

        var value = Parameter;
        var propertyValue = (value is not null) || IsSet(ParameterProperty)
            ? value
            : Converter?.Convert(parameter, typeof(object), ConverterParameter, null) ?? parameter;
        property.SetValue(target, propertyValue);
    }
}
