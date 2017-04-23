namespace Smart.Forms.Messaging
{
    using System.Collections.Generic;
    using System.Reflection;

    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    [ContentProperty("Actions")]
    public class MessageBehavior : BehaviorBase<VisualElement>
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
        public object Message { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IList<IMessageAction> Actions { get; } = new List<IMessageAction>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(VisualElement bindable)
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
            if ((Message == null) || Message.Equals(e.Message))
            {
                foreach (var action in Actions)
                {
                    if ((action.ParameterType == null) ||
                        ((e.Parameter != null) && e.Parameter.GetType().GetTypeInfo().IsAssignableFrom(action.ParameterType)))
                    {
                        action.Invoke(AssociatedObject, e.Parameter);
                    }
                }
            }
        }
    }
}
