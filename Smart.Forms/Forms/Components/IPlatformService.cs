namespace Smart.Forms.Components
{
    using System;

    public interface IPlatformService
    {
        void BeginInvokeOnMainThread(Action action);

        void StartTimer(TimeSpan interval, Func<bool> callBack);
    }
}
