namespace Smart.Forms.Messaging
{
    /// <summary>
    ///
    /// </summary>
    public class BusyIndicatorParameter
    {
        /// <summary>
        ///
        /// </summary>
        public static BusyIndicatorParameter True { get; } = new BusyIndicatorParameter(true);

        /// <summary>
        ///
        /// </summary>
        public static BusyIndicatorParameter False { get; } = new BusyIndicatorParameter(false);

        /// <summary>
        ///
        /// </summary>
        public bool IsBusy { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isBusy"></param>
        public BusyIndicatorParameter(bool isBusy)
        {
            IsBusy = isBusy;
        }
    }
}
