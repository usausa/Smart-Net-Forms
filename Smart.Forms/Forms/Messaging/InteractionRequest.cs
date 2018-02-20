namespace Smart.Forms.Messaging
{
    using System;

    public sealed class InteractionRequest : IInteractionRequest<EventArgs>
    {
        public event EventHandler<EventArgs> Requested;

        public void Request(EventArgs args)
        {
            Requested?.Invoke(this, args);
        }
    }

    public sealed class InteractionRequest<TEventAgrs> : IInteractionRequest<TEventAgrs>
        where TEventAgrs : EventArgs
    {
        public event EventHandler<TEventAgrs> Requested;

        public void Request(TEventAgrs args)
        {
            Requested?.Invoke(this, args);
        }
    }
}