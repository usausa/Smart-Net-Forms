namespace Smart.Forms.ViewModels
{
    using System;

    public static class BusyStateExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static IDisposable Begin(this IBusyState state) => new BusyStateScope(state);

        private readonly struct BusyStateScope : IDisposable
        {
            private readonly IBusyState state;

            public BusyStateScope(IBusyState state)
            {
                state.Require();
                this.state = state;
            }

            public void Dispose()
            {
                state.Release();
            }
        }
    }
}
