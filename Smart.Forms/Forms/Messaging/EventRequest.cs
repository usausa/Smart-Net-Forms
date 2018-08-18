namespace Smart.Forms.Messaging
{
    using System;

    public sealed class EventRequest : IEventRequest<EventEventArgs>
    {
        private static readonly EventEventArgs EmptyArgs = new EventEventArgs(null);

        public event EventHandler<EventEventArgs> Requested;

        public void Request()
        {
            Requested?.Invoke(this, EmptyArgs);
        }

        public void Request(object value)
        {
            Requested?.Invoke(this, new EventEventArgs(value));
        }
    }
}