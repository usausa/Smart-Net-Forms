namespace Smart.Forms.Messaging
{
    using System;

    public sealed class EventRequest : IEventRequest<EventRequestArgs>
    {
        private static readonly EventRequestArgs EmptyArgs = new EventRequestArgs(null);

        public event EventHandler<EventRequestArgs> Requested;

        public void Request()
        {
            Requested?.Invoke(this, EmptyArgs);
        }

        public void Request(object value)
        {
            Requested?.Invoke(this, new EventRequestArgs(value));
        }
    }
}