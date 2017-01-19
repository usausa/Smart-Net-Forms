namespace Smart.Forms.Interactivity
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class ParameterCallMethodBehavior : BehaviorBase<Element>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), propertyChanged: HandleEventNamePropertyChanged);

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetObjectProperty =
            BindableProperty.Create(nameof(TargetObject), typeof(object), typeof(ParameterCallMethodBehavior));

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MethodNameProperty =
            BindableProperty.Create(nameof(MethodName), typeof(string), typeof(ParameterCallMethodBehavior));

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MethodParameterProperty =
            BindableProperty.Create(nameof(MethodParameter), typeof(object), typeof(ParameterCallMethodBehavior));

        private EventInfo eventInfo;

        private Delegate handler;

        /// <summary>
        ///
        /// </summary>
        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        /// <summary>
        ///
        /// </summary>
        public object TargetObject
        {
            get { return GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        /// <summary>
        ///
        /// </summary>
        public string MethodName
        {
            get { return (string)GetValue(MethodNameProperty); }
            set { SetValue(MethodNameProperty, value); }
        }

        /// <summary>
        ///
        /// </summary>
        public object MethodParameter
        {
            get { return GetValue(MethodParameterProperty); }
            set { SetValue(MethodParameterProperty, value); }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(Element bindable)
        {
            base.OnAttachedTo(bindable);

            AddEventHandler(EventName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(Element bindable)
        {
            RemoveEventHandler();

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventName"></param>
        private void AddEventHandler(string eventName)
        {
            if (String.IsNullOrEmpty(eventName))
            {
                return;
            }

            eventInfo = AssociatedObject.GetType().GetRuntimeEvent(EventName);
            if (eventInfo == null)
            {
                throw new ArgumentException("EventName");
            }

            var methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
            handler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, handler);
        }

        /// <summary>
        ///
        /// </summary>
        private void RemoveEventHandler()
        {
            eventInfo?.RemoveEventHandler(AssociatedObject, handler);
            eventInfo = null;
            handler = null;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Ignore")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("ReSharper", "UnusedParameter.Local", Justification = "Ignore")]
        private void OnEvent(object sender, EventArgs e)
        {
            if ((TargetObject == null) || string.IsNullOrEmpty(MethodName))
            {
                return;
            }

            var methodInfo = TargetObject.GetType().GetRuntimeMethods().FirstOrDefault(m =>
                m.Name == MethodName &&
                m.GetParameters().Length == 1 &&
                ((MethodParameter == null) || MethodParameter.GetType().GetTypeInfo().IsAssignableFrom(m.GetParameters()[0].ParameterType.GetTypeInfo())));
            methodInfo?.Invoke(TargetObject, new[] { MethodParameter });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void HandleEventNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (ParameterCallMethodBehavior)bindable;
            if (behavior.AssociatedObject == null)
            {
                return;
            }

            behavior.RemoveEventHandler();
            behavior.AddEventHandler((string)newValue);
        }
    }
}
