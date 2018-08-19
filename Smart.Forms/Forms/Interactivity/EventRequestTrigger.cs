namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    public sealed class EventRequestTrigger : RequestTriggerBase<ParamterEventArgs>
    {
        protected override void OnEventRequest(object sender, ParamterEventArgs e)
        {
            InvokeActions(e.Parameter);
        }
    }
}
