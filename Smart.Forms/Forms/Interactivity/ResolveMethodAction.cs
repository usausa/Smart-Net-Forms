namespace Smart.Forms.Interactivity
{
    using System.Linq;
    using System.Reflection;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    public sealed class ResolveMethodAction : ActionBase<BindableObject, ResultEventArgs>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
            nameof(TargetObject),
            typeof(object),
            typeof(ResolveMethodAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MethodNameProperty = BindableProperty.Create(
            nameof(MethodName),
            typeof(string),
            typeof(ResolveMethodAction));

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

        private MethodInfo cachedMethod;

        protected override void Invoke(BindableObject associatedObject, ResultEventArgs parameter)
        {
            var target = TargetObject ?? associatedObject;
            var methodName = MethodName;
            if ((target == null) || (methodName == null))
            {
                return;
            }

            if ((cachedMethod == null) ||
                (cachedMethod.DeclaringType != target.GetType() ||
                 (cachedMethod.Name != methodName)))
            {
                var methodInfo = target.GetType().GetRuntimeMethods().FirstOrDefault(m =>
                    m.Name == methodName &&
                    (m.GetParameters().Length == 0));
                if (methodInfo == null)
                {
                    return;
                }

                cachedMethod = methodInfo;
            }

            parameter.Result = cachedMethod.Invoke(target, null);
        }
    }
}
