namespace Smart.Forms.Interactivity
{
    using System.Reflection;

    using Xamarin.Forms;

    public sealed class ChangePropertyAction : BindableObject, IAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
            nameof(TargetObject),
            typeof(object),
            typeof(ChangePropertyAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty PropertyNameProperty = BindableProperty.Create(
            nameof(PropertyName),
            typeof(string),
            typeof(ChangePropertyAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(object),
            typeof(ChangePropertyAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ConverterProperty = BindableProperty.Create(
            nameof(Converter),
            typeof(IValueConverter),
            typeof(ChangePropertyAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ConverterParameterProperty = BindableProperty.Create(
            nameof(ConverterParameter),
            typeof(object),
            typeof(ChangePropertyAction));

        public object TargetObject
        {
            get => GetValue(TargetObjectProperty);
            set => SetValue(TargetObjectProperty, value);
        }

        public string PropertyName
        {
            get => (string)GetValue(PropertyNameProperty);
            set => SetValue(PropertyNameProperty, value);
        }

        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
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

        private PropertyInfo property;

        public void DoInvoke(BindableObject associatedObject, object parameter)
        {
            var target = TargetObject ?? associatedObject;
            var propertyName = PropertyName;
            if ((target is null) || (propertyName is null))
            {
                return;
            }

            if ((property is null) ||
                (property.DeclaringType != target.GetType()) ||
                (property.Name != propertyName))
            {
                property = target.GetType().GetRuntimeProperty(propertyName);
            }

            var value = Value;
            var propertyValue = (value != null) || IsSet(ValueProperty)
                ? value
                : Converter?.Convert(parameter, typeof(object), ConverterParameter, null) ?? parameter;
            property.SetValue(target, propertyValue);
        }
    }
}
