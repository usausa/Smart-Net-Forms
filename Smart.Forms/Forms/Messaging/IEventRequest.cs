namespace Smart.Forms.Messaging
{
    using System;

    public interface IEventRequest<TEventArgs>
        where TEventArgs : EventArgs
    {
        event EventHandler<TEventArgs> Requested;
    }
}
