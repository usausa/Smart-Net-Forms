namespace Smart.Forms.Interactivity
{
    using System.Reflection;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    public sealed class ResolvePropertyAction : ActionBase<BindableObject, ResultEventArgs>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
            nameof(TargetObject),
            typeof(object),
            typeof(ResolvePropertyAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty PropertyNameProperty = BindableProperty.Create(
            nameof(PropertyName),
            typeof(string),
            typeof(ResolvePropertyAction));

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

        private PropertyInfo property;

        protected override void Invoke(BindableObject associatedObject, ResultEventArgs parameter)
        {
            var target = TargetObject ?? associatedObject;
            var propertyName = PropertyName;
            if ((target == null) || (propertyName == null))
            {
                return;
            }

            if ((property == null) ||
                (property.DeclaringType != target.GetType()) ||
                (property.Name != propertyName))
            {
                property = target.GetType().GetRuntimeProperty(propertyName);
            }

            parameter.Result = property.GetValue(target);
        }
    }
}
