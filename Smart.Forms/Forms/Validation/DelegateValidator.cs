namespace Smart.Forms.Validation;

public sealed class DelegateValidator<T> : IValidator<T>
{
    private readonly Func<T, bool> predicate;

    public string ErrorMessage { get; set; } = string.Empty;

    public DelegateValidator(Func<T, bool> predicate)
    {
        this.predicate = predicate;
    }

    public bool Validate(T value)
    {
        return predicate(value);
    }
}
