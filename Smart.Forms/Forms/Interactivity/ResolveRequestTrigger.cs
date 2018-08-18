namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    /// <summary>
    ///
    /// </summary>
    public sealed class ResolveRequestTrigger : RequestTriggerBase<ResolveEventArgs>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnEventRequest(object sender, ResolveEventArgs e)
        {
            InvokeActions(e);
        }
    }
}
