namespace Smart.Forms.Messaging
{
    using System;

    public sealed class EventRequestArgs : EventArgs
    {
        public object Value { get; }

        public EventRequestArgs(object value)
        {
            Value = value;
        }
    }
}
