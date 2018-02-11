namespace Smart.Forms.Validation
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public sealed class ValidationRequest
    {
        /// <summary>
        ///
        /// </summary>
        public event EventHandler<EventArgs> ValidationErrorRequested;

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Ignore")]
        public void RaiseValidationError()
        {
            ValidationErrorRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
