namespace Smart.Forms.Interactivity
{
    using System.Linq;
    using System.Reflection;

    using Xamarin.Forms;

    public sealed class CallMethodAction : BindableObject, IAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
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

        public object Target
        {
            get => GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
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

        private MethodDescriptor cachedMethod;

        public void DoInvoke(BindableObject associatedObject, object parameter)
        {
            var target = Target ?? associatedObject;
            if ((target == null) || (MethodName == null))
            {
                return;
            }

            if ((cachedMethod == null) ||
                (cachedMethod.Method.DeclaringType != target.GetType() ||
                (cachedMethod.Method.Name != MethodName)))
            {
                var methodInfo = target.GetType().GetRuntimeMethods().FirstOrDefault(m =>
                    m.Name == MethodName &&
                    ((m.GetParameters().Length == 0) ||
                     ((m.GetParameters().Length == 1) &&
                      ((MethodParameter == null) ||
                       MethodParameter.GetType().GetTypeInfo().IsAssignableFrom(m.GetParameters()[0].ParameterType.GetTypeInfo())))));
                if (methodInfo == null)
                {
                    return;
                }

                cachedMethod = new MethodDescriptor(methodInfo, methodInfo.GetParameters().Length > 0);
            }

            cachedMethod.Method.Invoke(target, cachedMethod.HasParameter ? new[] { MethodParameter } : null);
        }

        private static void HandleMethodParameterPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CallMethodAction)bindable).cachedMethod = null;
        }
    }
}
