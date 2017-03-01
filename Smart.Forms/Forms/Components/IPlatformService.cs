namespace Smart.Forms.Components
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public interface IPlatformService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="action"></param>
        void BeginInvokeOnMainThread(Action action);

        /// <summary>
        ///
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="callBack"></param>
        void StartTimer(TimeSpan interval, Func<bool> callBack);
    }
}
