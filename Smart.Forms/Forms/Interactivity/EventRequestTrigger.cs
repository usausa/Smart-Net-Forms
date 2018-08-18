namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    public sealed class EventRequestTrigger : RequestTriggerBase<EventEventArgs>
    {
        protected override void OnEventRequest(object sender, EventEventArgs e)
        {
            InvokeActions(e.Value);
        }
    }
}
