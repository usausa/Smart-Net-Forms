namespace Smart.Forms.Validation
{
    using System;
    using System.Globalization;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StringLengthRule<T> : IValidationRule<T>
    {
        private readonly int minLength;

        private readonly int maxLength;

        /// <summary>
        ///
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="maxLength"></param>
        public StringLengthRule(int maxLength)
            : this(0, maxLength)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        public StringLengthRule(int minLength, int maxLength)
        {
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Validate(T value)
        {
            if (value == null)
            {
                return true;
            }

            var str = Convert.ToString(value, CultureInfo.CurrentCulture);

            return (str.Length >= minLength) && (str.Length <= maxLength);
        }
    }
}
