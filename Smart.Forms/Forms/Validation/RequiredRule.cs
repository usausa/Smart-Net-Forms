namespace Smart.Forms.Validation
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequiredRule<T> : IValidator<T>
    {
        /// <summary>
        ///
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Validate(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            return !String.IsNullOrWhiteSpace(str);
        }
    }
}
