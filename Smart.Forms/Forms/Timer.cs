namespace Smart.Forms;

using Xamarin.Forms;

public sealed class Timer : IDisposable
{
    private readonly TimeSpan dueTime;

    private readonly Action callback;

    private int running;

    public Timer(TimeSpan dueTime, Action callback)
    {
        this.dueTime = dueTime;
        this.callback = callback;
    }

    public void Dispose()
    {
        Stop();
    }

#pragma warning disable CA1711
    public static Timer StartNew(TimeSpan dueTime, Action callback)
    {
        var timer = new Timer(dueTime, callback);
        timer.Start();
        return timer;
    }
#pragma warning restore CA1711

    public void Start()
    {
        if (Interlocked.Exchange(ref running, 1) == 0)
        {
            Device.StartTimer(dueTime, () =>
            {
                var state = Interlocked.Exchange(ref running, running) == 1;
                if (state)
                {
                    callback();
                }

                return state;
            });
        }
    }

    public void Stop()
    {
        Interlocked.Exchange(ref running, 0);
    }
}
