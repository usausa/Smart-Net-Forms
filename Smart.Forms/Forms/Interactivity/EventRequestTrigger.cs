namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    public sealed class EventRequestTrigger : RequestTriggerBase<ParameterEventArgs>
    {
        protected override void OnEventRequest(object sender, ParameterEventArgs e)
        {
            InvokeActions(e.Parameter);
        }
    }
}
