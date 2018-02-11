namespace Smart.Forms.Components
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public sealed class PlatformService : IPlatformService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="action"></param>
        public void BeginInvokeOnMainThread(Action action)
        {
            Device.BeginInvokeOnMainThread(action);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="callBack"></param>
        public void StartTimer(TimeSpan interval, Func<bool> callBack)
        {
            Device.StartTimer(interval, callBack);
        }
    }
}
