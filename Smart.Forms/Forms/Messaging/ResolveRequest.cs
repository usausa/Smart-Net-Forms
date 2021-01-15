namespace Smart.Forms.Messaging
{
    using System;

    public sealed class ResolveRequest<T> : IEventRequest<ResultEventArgs>
    {
        public event EventHandler<ResultEventArgs> Requested;

        public T Resolve()
        {
            var args = new ResultEventArgs();
            Requested?.Invoke(this, args);
            return (T)args.Result;
        }
    }
}
