namespace Smart.Forms.Validation
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateRule<T> : IValidationRule<T>
    {
        private readonly Func<T, bool> predicate;

        /// <summary>
        ///
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="predicate"></param>
        public DelegateRule(Func<T, bool> predicate)
        {
            this.predicate = predicate;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Validate(T value)
        {
            return predicate(value);
        }
    }
}
