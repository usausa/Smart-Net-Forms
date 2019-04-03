namespace Smart.Forms.Interactivity
{
    using System.Linq;
    using System.Reflection;

    using Xamarin.Forms;

    public sealed class CallMethodAction : BindableObject, IAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
            nameof(TargetObject),
            typeof(object),
            typeof(CallMethodAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MethodNameProperty = BindableProperty.Create(
            nameof(MethodName),
            typeof(string),
            typeof(CallMethodAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MethodParameterProperty = BindableProperty.Create(
            nameof(MethodParameter),
            typeof(object),
            typeof(CallMethodAction),
            propertyChanged: HandleMethodParameterPropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ConverterProperty = BindableProperty.Create(
            nameof(Converter),
            typeof(IValueConverter),
            typeof(CallMethodAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ConverterParameterProperty = BindableProperty.Create(
            nameof(ConverterParameter),
            typeof(object),
            typeof(CallMethodAction));

        public object TargetObject
        {
            get => GetValue(TargetObjectProperty);
            set => SetValue(TargetObjectProperty, value);
        }

        public string MethodName
        {
            get => (string)GetValue(MethodNameProperty);
            set => SetValue(MethodNameProperty, value);
        }

        public object MethodParameter
        {
            get => GetValue(MethodParameterProperty);
            set => SetValue(MethodParameterProperty, value);
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

        private MethodInfo cachedMethod;

        public void DoInvoke(BindableObject associatedObject, object parameter)
        {
            var target = TargetObject ?? associatedObject;
            var methodName = MethodName;
            if ((target is null) || (methodName is null))
            {
                return;
            }

            if ((cachedMethod is null) ||
                (cachedMethod.DeclaringType != target.GetType() ||
                (cachedMethod.Name != methodName)))
            {
                var methodInfo = target.GetType().GetRuntimeMethods().FirstOrDefault(m =>
                    m.Name == methodName &&
                    ((m.GetParameters().Length == 0) ||
                     ((m.GetParameters().Length == 1) &&
                      ((MethodParameter is null) ||
                       MethodParameter.GetType().GetTypeInfo().IsAssignableFrom(m.GetParameters()[0].ParameterType.GetTypeInfo())))));
                if (methodInfo is null)
                {
                    return;
                }

                cachedMethod = methodInfo;
            }

            if (cachedMethod.GetParameters().Length > 0)
            {
                var methodParameter = MethodParameter;
                var argument = (methodParameter != null) || IsSet(MethodParameterProperty)
                    ? methodParameter
                    : Converter?.Convert(parameter, typeof(object), ConverterParameter, null) ?? parameter;
                cachedMethod.Invoke(target, new[] { argument });
            }
            else
            {
                cachedMethod.Invoke(target, null);
            }
        }

        private static void HandleMethodParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CallMethodAction)bindable).cachedMethod = null;
        }
    }
}
