﻿namespace Smart.Forms.Internal
{
    using System;

    internal sealed class DelegateDisposable : IDisposable
    {
        private readonly Action action;

        public DelegateDisposable(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            action();
        }
    }
}
