namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    public sealed class EventRequestTrigger : RequestTriggerBase<EventRequestArgs>
    {
        protected override void OnEventRequest(object sender, EventRequestArgs e)
        {
            InvokeActions(e.Value);
        }
    }
}
