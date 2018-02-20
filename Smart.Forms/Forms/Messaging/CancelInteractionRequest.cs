namespace Smart.Forms.Messaging
{
    using System;
    using System.ComponentModel;

    public sealed class CancelInteractionRequest : IInteractionRequest<CancelEventArgs>
    {
        public event EventHandler<CancelEventArgs> Requested;

        public bool IsCancel()
        {
            var args = new CancelEventArgs();
            Requested?.Invoke(this, args);
            return args.Cancel;
        }
    }
}
