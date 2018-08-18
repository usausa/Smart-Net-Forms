namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    public sealed class ResolveRequestTrigger : RequestTriggerBase<ResolveEventArgs>
    {
        protected override void OnEventRequest(object sender, ResolveEventArgs e)
        {
            InvokeActions(e);
        }
    }
}
