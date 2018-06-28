namespace Smart.Forms.Messaging
{
    using System;

    public sealed class ResolveInteractionRequest<T> : IInteractionRequest<ValueHolderEventArgs>
    {
        public event EventHandler<ValueHolderEventArgs> Requested;

        public T Resolve()
        {
            var args = new ValueHolderEventArgs();
            Requested?.Invoke(this, args);
            return (T)args.Value;
        }
    }
}
