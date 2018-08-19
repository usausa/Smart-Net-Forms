namespace Smart.Forms.Messaging
{
    using System;

    public sealed class ParamterEventArgs : EventArgs
    {
        public object Parameter { get; }

        public ParamterEventArgs(object parameter)
        {
            Parameter = parameter;
        }
    }
}
