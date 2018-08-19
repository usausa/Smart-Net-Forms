﻿namespace Smart.Forms.Interactivity
{
    using System;
    using System.Reflection;

    using Xamarin.Forms;

    public sealed class EventTrigger : TriggerBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty EventNameProperty = BindableProperty.Create(
            nameof(EventName),
            typeof(string),
            typeof(EventTrigger),
            propertyChanged: HandleEventNamePropertyChanged);

        private EventInfo eventInfo;

        private Delegate handler;

        public string EventName
        {
            get => (string)GetValue(EventNameProperty);
            set => SetValue(EventNameProperty, value);
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
                throw new ArgumentException("EventName");
            }

            var methodInfo = typeof(EventTrigger).GetTypeInfo().GetDeclaredMethod("OnEvent");
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
            InvokeActions(null);
        }

        private static void HandleEventNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (EventTrigger)bindable;
            if (behavior.AssociatedObject == null)
            {
                return;
            }

            behavior.RemoveEventHandler();
            behavior.AddEventHandler((string)newValue);
        }
    }
}