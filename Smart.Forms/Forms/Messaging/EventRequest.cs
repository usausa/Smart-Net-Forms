namespace Smart.Forms.Messaging
{
    using System;

    public sealed class EventRequest : IEventRequest<ParamterEventArgs>
    {
        private static readonly ParamterEventArgs EmptyArgs = new ParamterEventArgs(null);

        public event EventHandler<ParamterEventArgs> Requested;

        public void Request()
        {
            Requested?.Invoke(this, EmptyArgs);
        }
    }

    public sealed class EventRequest<T> : IEventRequest<ParamterEventArgs>
    {
        public event EventHandler<ParamterEventArgs> Requested;

        public void Request(T value)
        {
            Requested?.Invoke(this, new ParamterEventArgs(value));
        }
    }
}