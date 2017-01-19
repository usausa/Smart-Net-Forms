namespace Smart.Forms.Interactivity
{
    using System.Collections.Generic;
    using System.Reflection;

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
            BindableProperty.Create(nameof(Messenger), typeof(Messenger), typeof(MessageBehavior), null, BindingMode.OneWay, null, MessengerPropertyChanged);

        /// <summary>
        ///
        /// </summary>
        public Messenger Messenger
        {
            get { return (Messenger)GetValue(MessengerProperty); }
            set { SetValue(MessengerProperty, value); }
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
        private BindableObject associatedObject;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(Element bindable)
        {
            base.OnAttachedTo(bindable);

            associatedObject = bindable;
        }

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

            associatedObject = null;

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void MessengerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            var behavior = (MessageBehavior)bindable;

            if ((oldValue != null) && (behavior.Messenger != null))
            {
                behavior.Messenger.Recieved -= behavior.MessengerOnRecieved;
            }

            if ((newValue != null) && (behavior.Messenger != null))
            {
                behavior.Messenger.Recieved += behavior.MessengerOnRecieved;
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
                        action.Invoke(associatedObject, e.Parameter);
                    }
                }
            }
        }
    }
}
