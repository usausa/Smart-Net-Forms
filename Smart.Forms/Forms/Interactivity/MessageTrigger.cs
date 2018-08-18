namespace Smart.Forms.Interactivity
{
    using System;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class MessageTrigger : TriggerBase<BindableObject>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MessengerProperty = BindableProperty.Create(
            nameof(Messenger),
            typeof(IMessenger),
            typeof(MessageTrigger),
            null,
            propertyChanged: OnMessengerPropertyChanged);

        /// <summary>
        ///
        /// </summary>
        public IMessenger Messenger
        {
            get => (IMessenger)GetValue(MessengerProperty);
            set => SetValue(MessengerProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Type MessageType { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if (Messenger != null)
            {
                Messenger.Recieved -= MessengerOnRecieved;
            }

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnMessengerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((MessageTrigger)bindable).OnMessengerPropertyChanged(oldValue as IMessenger, newValue as IMessenger);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private void OnMessengerPropertyChanged(IMessenger oldValue, IMessenger newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            if (oldValue != null)
            {
                oldValue.Recieved -= MessengerOnRecieved;
            }

            if (newValue != null)
            {
                newValue.Recieved += MessengerOnRecieved;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessengerOnRecieved(object sender, MessengerEventArgs e)
        {
            if (((Label == null) || Label.Equals(e.Label)) &&
                ((MessageType == null) || ((e.MessageType != null) && MessageType.IsAssignableFrom(e.MessageType))))
            {
                InvokeActions(e.Message);
            }
        }
    }
}
