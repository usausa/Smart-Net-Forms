namespace Smart.Forms.Messaging
{
    using System.Threading.Tasks;

    /// <summary>
    ///
    /// </summary>
    public class DisplayAlertParameter
    {
        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Cancel { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Task<bool> Result { get; set; }
    }
}
