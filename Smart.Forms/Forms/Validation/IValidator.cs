namespace Smart.Forms.Validation
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<in T>
    {
        /// <summary>
        ///
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Validate(T value);
    }
}
