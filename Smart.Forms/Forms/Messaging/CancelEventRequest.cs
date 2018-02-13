﻿namespace Smart.Forms.Messaging
{
    using System;
    using System.ComponentModel;

    public sealed class CancelEventRequest : IEventRequest<CancelEventArgs>
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