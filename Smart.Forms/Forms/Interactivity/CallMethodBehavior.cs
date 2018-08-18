namespace Smart.Forms.Interactivity
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Xamarin.Forms;

    public sealed class CallMethodBehavior : BehaviorBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty EventNameProperty = BindableProperty.Create(
            nameof(EventName),
            typeof(string),
            typeof(CallMethodBehavior),
            propertyChanged: HandleEventNamePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
            nameof(TargetObject),
            typeof(object),
            typeof(CallMethodBehavior));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MethodNameProperty = BindableProperty.Create(
            nameof(MethodName),
            typeof(string),
            typeof(CallMethodBehavior));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MethodParameterProperty = BindableProperty.Create(
            nameof(MethodParameter),
            typeof(object),
            typeof(CallMethodBehavior),
            propertyChanged: HandleMethodParameterPropertyChanged);

        private EventInfo eventInfo;

        private Delegate handler;

        private MethodDescriptor cachedMethod;

        public string EventName
        {
            get => (string)GetValue(EventNameProperty);
            set => SetValue(EventNameProperty, value);
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            AddEventHandler(EventName);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
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

            eventInfo = AssociatedObject.GetType().GetRuntimeEvent(EventName);
            if (eventInfo == null)
            {
                throw new ArgumentException(nameof(EventName));
            }

            var methodInfo = typeof(CallMethodBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
            handler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, handler);
        }

        private void RemoveEventHandler()
        {
            eventInfo?.RemoveEventHandler(AssociatedObject, handler);
            eventInfo = null;
            handler = null;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Ignore")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = "Ignore")]
        private void OnEvent(object sender, EventArgs e)
        {
            if ((TargetObject == null) || string.IsNullOrEmpty(MethodName))
            {
                return;
            }

            if ((cachedMethod == null) ||
                (cachedMethod.Method.DeclaringType != TargetObject.GetType() ||
                 (cachedMethod.Method.Name != MethodName)))
            {
                var methodInfo = TargetObject.GetType().GetRuntimeMethods().FirstOrDefault(m =>
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

            cachedMethod.Method.Invoke(TargetObject, cachedMethod.HasParameter ? new[] { MethodParameter } : null);
        }

        private static void HandleEventNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (CallMethodBehavior)bindable;
            if (behavior.AssociatedObject == null)
            {
                return;
            }

            behavior.RemoveEventHandler();
            behavior.AddEventHandler((string)newValue);
        }

        private static void HandleMethodParameterPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CallMethodBehavior)bindable).cachedMethod = null;
        }
    }
}
