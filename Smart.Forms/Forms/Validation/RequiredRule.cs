namespace Smart.Forms.Validation;

public sealed class RequiredRule<T> : IValidator<T>
{
    public string ErrorMessage { get; set; } = string.Empty;

    public bool Validate(T value)
    {
        if (value is null)
        {
            return false;
        }

        var str = value as string;
        return !String.IsNullOrWhiteSpace(str);
    }
}
