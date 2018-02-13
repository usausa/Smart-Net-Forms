namespace Smart.Forms.Interactivity
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class EventTriggerBehavior : TriggerBehaviorBase<BindableObject>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty EventNameProperty = BindableProperty.Create(
            nameof(EventName),
            typeof(string),
            typeof(EventTriggerBehavior),
            propertyChanged: HandleEventNamePropertyChanged);

        private EventInfo eventInfo;

        private Delegate handler;

        /// <summary>
        ///
        /// </summary>
        public string EventName
        {
            get => (string)GetValue(EventNameProperty);
            set => SetValue(EventNameProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            AddEventHandler(EventName);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(BindableObject bindable)
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

            var methodInfo = typeof(EventTriggerBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");
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
            InvokeActions(null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void HandleEventNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (EventTriggerBehavior)bindable;
            if (behavior.AssociatedObject == null)
            {
                return;
            }

            behavior.RemoveEventHandler();
            behavior.AddEventHandler((string)newValue);
        }
    }
}
