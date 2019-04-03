namespace Smart.Forms.Validation
{
    using System;

    public sealed class DelegateValidator<T> : IValidator<T>
    {
        private readonly Func<T, bool> predicate;

        public string ErrorMessage { get; set; }

        public DelegateValidator(Func<T, bool> predicate)
        {
            this.predicate = predicate;
        }

        public bool Validate(T value)
        {
            return predicate(value);
        }
    }
}
