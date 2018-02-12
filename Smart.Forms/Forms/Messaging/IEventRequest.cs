namespace Smart.Forms.Messaging
{
    using System;

    public interface IEventRequest<TEventAgrs>
        where TEventAgrs : EventArgs
    {
        event EventHandler<TEventAgrs> Requested;
    }
}
