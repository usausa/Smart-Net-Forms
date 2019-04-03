namespace Smart.Forms.Validation
{
    public interface IValidator<in T>
    {
        string ErrorMessage { get; }

        bool Validate(T value);
    }
}
