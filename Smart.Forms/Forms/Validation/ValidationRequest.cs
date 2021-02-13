namespace Smart.Forms.Validation
{
    using System;

    public sealed class ValidationRequest
    {
        public event EventHandler<EventArgs> ValidationErrorRequested;

        public void RaiseValidationError()
        {
            ValidationErrorRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
