namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    public sealed class ResolveRequestTrigger : RequestTriggerBase<ResultEventArgs>
    {
        protected override void OnEventRequest(object sender, ResultEventArgs e)
        {
            InvokeActions(e);
        }
    }
}
