namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Messaging;

    /// <summary>
    ///
    /// </summary>
    public sealed class ResolveInteractionHandleBehavior : InteractionHandleBehaviorBase<ValueHolderEventArgs>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnEventRequest(object sender, ValueHolderEventArgs e)
        {
            InvokeActions(e);
        }
    }
}
