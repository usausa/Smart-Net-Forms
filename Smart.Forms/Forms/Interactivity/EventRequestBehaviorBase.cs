﻿namespace Smart.Forms.Interactivity
{
    using System;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    public abstract class EventRequestBehaviorBase<TEventArgs> : TriggerBehaviorBase<BindableObject>
        where TEventArgs : EventArgs
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty EventRequestProperty = BindableProperty.Create(
            nameof(EventRequest),
            typeof(IEventRequest<TEventArgs>),
            typeof(EventRequestBehaviorBase<TEventArgs>),
            null,
            propertyChanged: OnEventRequestPropertyChanged);

        /// <summary>
        ///
        /// </summary>
        public IEventRequest<TEventArgs> EventRequest
        {
            get => (IEventRequest<TEventArgs>)GetValue(EventRequestProperty);
            set => SetValue(EventRequestProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if (EventRequest != null)
            {
                EventRequest.Requested -= EventRequestOnRequested;
            }

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnEventRequestPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((EventRequestBehaviorBase<TEventArgs>)bindable).OnMessengerPropertyChanged(oldValue as IEventRequest<TEventArgs>, newValue as IEventRequest<TEventArgs>);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private void OnMessengerPropertyChanged(IEventRequest<TEventArgs> oldValue, IEventRequest<TEventArgs> newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            if (oldValue != null)
            {
                oldValue.Requested -= EventRequestOnRequested;
            }

            if (newValue != null)
            {
                newValue.Requested += EventRequestOnRequested;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventRequestOnRequested(object sender, TEventArgs e)
        {
            OnEventRequest(sender, e);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected abstract void OnEventRequest(object sender, TEventArgs e);
    }
}