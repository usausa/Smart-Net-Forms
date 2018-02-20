namespace Smart.Forms.Messaging
{
    using System;

    public interface IInteractionRequest<TEventAgrs>
        where TEventAgrs : EventArgs
    {
        event EventHandler<TEventAgrs> Requested;
    }
}
