﻿namespace Smart.Forms.Interactivity
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public sealed class InteractionHandleBehavior : InteractionHandleBehaviorBase<EventArgs>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnEventRequest(object sender, EventArgs e)
        {
            InvokeActions(null);
        }
    }
}