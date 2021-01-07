namespace Smart.Forms.Interactivity
{
    using System;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    public sealed class MessageTrigger : TriggerBase<BindableObject>
    {
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

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if (Messenger is not null)
            {
                Messenger.Received -= MessengerOnReceived;
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

            if (oldValue is not null)
            {
                oldValue.Received -= MessengerOnReceived;
            }

            if (newValue is not null)
            {
                newValue.Received += MessengerOnReceived;
            }
        }

        private void MessengerOnReceived(object sender, MessengerEventArgs e)
        {
            var label = Label;
            var messageType = MessageType;
            if (((label is null) || label.Equals(e.Label, StringComparison.Ordinal)) &&
                ((messageType is null) || ((e.MessageType is not null) && messageType.IsAssignableFrom(e.MessageType))))
            {
                InvokeActions(e.Message);
            }
        }
    }
}
