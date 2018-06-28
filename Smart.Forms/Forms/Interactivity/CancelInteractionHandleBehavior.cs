﻿namespace Smart.Forms.Interactivity
{
    using System.ComponentModel;

    /// <summary>
    ///
    /// </summary>
    public sealed class CancelInteractionHandleBehavior : InteractionHandleBehaviorBase<CancelEventArgs>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnEventRequest(object sender, CancelEventArgs e)
        {
            InvokeActions(e);
        }
    }
}