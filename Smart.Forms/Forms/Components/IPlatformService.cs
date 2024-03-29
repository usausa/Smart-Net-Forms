namespace Smart.Forms.Components;

public interface IPlatformService
{
    void BeginInvokeOnMainThread(Action action);

    void StartTimer(TimeSpan interval, Func<bool> callBack);
}
