namespace Smart.Forms.Validation
{
    using System;
    using System.Globalization;

    public sealed class StringLengthValidator<T> : IValidator<T>
    {
        private readonly int minLength;

        private readonly int maxLength;

        public string ErrorMessage { get; set; } = string.Empty;

        public StringLengthValidator(int maxLength)
            : this(0, maxLength)
        {
        }

        public StringLengthValidator(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public bool Validate(T value)
        {
            if (value is null)
            {
                return true;
            }

            var str = Convert.ToString(value, CultureInfo.CurrentCulture);

            return (str.Length >= minLength) && (str.Length <= maxLength);
        }
    }
}
