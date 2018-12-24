namespace Smart.Forms
{
    using System;
    using System.Threading;

    using Xamarin.Forms;

    public sealed class Timer
    {
        private readonly TimeSpan dueTime;

        private readonly Action callback;

        private int running;

        public Timer(TimeSpan dueTime, Action callback)
        {
            this.dueTime = dueTime;
            this.callback = callback;
        }

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
}
