namespace Smart.Forms.Interactivity
{
    using System;
    using System.Collections.Generic;

    using Smart.Forms.Messaging;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    [ContentProperty("Actions")]
    public class MessageBehavior : BehaviorBase<Element>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty MessengerProperty =
            BindableProperty.Create(nameof(Messenger), typeof(Messenger), typeof(MessageBehavior), null, propertyChanged: OnMessengerPropertyChanged);

        /// <summary>
        ///
        /// </summary>
        public Messenger Messenger
        {
            get => (Messenger)GetValue(MessengerProperty);
            set => SetValue(MessengerProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IList<IMessageAction> Actions { get; } = new List<IMessageAction>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(Element bindable)
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
            ((MessageBehavior)bindable).OnMessengerPropertyChanged(oldValue as Messenger, newValue as Messenger);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private void OnMessengerPropertyChanged(Messenger oldValue, Messenger newValue)
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
            if (((Message == null) || Message.Equals(e.Message)) &&
                ((Type == null) || ((e.Parameter != null) && Type.IsInstanceOfType(e.Parameter))))
            {
                foreach (var action in Actions)
                {
                    action.Invoke(AssociatedObject, e.Parameter);
                }
            }
        }
    }
}
