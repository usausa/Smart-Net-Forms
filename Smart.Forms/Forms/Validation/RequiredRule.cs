namespace Smart.Forms.Validation
{
    using System;

    public sealed class RequiredRule<T> : IValidator<T>
    {
        public string ErrorMessage { get; set; }

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
}
