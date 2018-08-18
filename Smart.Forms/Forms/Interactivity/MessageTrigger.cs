namespace Smart.Forms.Interactivity
{
    using System;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    public sealed class MessageTrigger : TriggerBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MessengerProperty = BindableProperty.Create(
            nameof(Messenger),
            typeof(IMessenger),
            typeof(MessageTrigger),
            null,
            propertyChanged: HandleMessengerPropertyChanged);

        public IMessenger Messenger
        {
            get => (IMessenger)GetValue(MessengerProperty);
            set => SetValue(MessengerProperty, value);
        }

        public string Label { get; set; }

        public Type MessageType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if (Messenger != null)
            {
                Messenger.Recieved -= MessengerOnRecieved;
            }

            base.OnDetachingFrom(bindable);
        }

        private static void HandleMessengerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((MessageTrigger)bindable).HandleMessengerPropertyChanged(oldValue as IMessenger, newValue as IMessenger);
        }

        private void HandleMessengerPropertyChanged(IMessenger oldValue, IMessenger newValue)
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
