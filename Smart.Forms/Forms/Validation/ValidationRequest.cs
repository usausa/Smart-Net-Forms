namespace Smart.Forms.Validation;

public sealed class ValidationRequest
{
    public event EventHandler<EventArgs>? ValidationErrorRequested;

#pragma warning disable CA1030
    public void RaiseValidationError()
    {
        ValidationErrorRequested?.Invoke(this, EventArgs.Empty);
    }
#pragma warning restore CA1030
}
