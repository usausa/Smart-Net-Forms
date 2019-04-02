namespace Smart.Forms.Validation
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class RegexValidator<T> : IValidator<T>
    {
        private readonly Regex regex;

        /// <summary>
        ///
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="regex"></param>
        public RegexValidator(Regex regex)
        {
            this.regex = regex;
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
            var m = regex.Match(str);

            return m.Success && (m.Index == 0) && (m.Length == str.Length);
        }
    }
}
