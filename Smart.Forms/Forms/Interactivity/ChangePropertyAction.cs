namespace Smart.Forms.Interactivity
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;

    public sealed class ChangePropertyAction : BindableObject, IAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
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

        public object Target
        {
            get => GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
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

        public void DoInvoke(BindableObject associatedObject, object parameter)
        {
            var target = Target ?? associatedObject;
            if ((target == null) || (PropertyName == null))
            {
                return;
            }

            var pi = target.GetType().GetRuntimeProperty(PropertyName);

            object value;
            if (Value == null)
            {
                value = Value;
            }
            else if (pi.PropertyType.IsAssignableFrom(Value.GetType().GetTypeInfo()))
            {
                value = Value;
            }
            else
            {
                var str = Value.ToString();
                var propertyType = pi.PropertyType;
                value = propertyType.IsEnum ? Enum.Parse(propertyType, str) : Convert.ChangeType(Value, propertyType);
            }

            pi.SetValue(target, value);
        }
    }
}
