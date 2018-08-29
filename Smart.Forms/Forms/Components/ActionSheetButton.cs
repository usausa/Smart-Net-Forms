namespace Smart.Forms.Components
{
    using System.Windows.Input;

    /// <summary>
    ///
    /// </summary>
    public sealed class ActionSheetButton
    {
        /// <summary>
        ///
        /// </summary>
        public ActionSheetButtonType ButtonType { get; }

        /// <summary>
        ///
        /// </summary>
        public string Text { get; }

        /// <summary>
        ///
        /// </summary>
        public ICommand Command { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="buttonType"></param>
        /// <param name="text"></param>
        /// <param name="command"></param>
        private ActionSheetButton(ActionSheetButtonType buttonType, string text, ICommand command)
        {
            ButtonType = buttonType;
            Text = text;
            Command = command;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static ActionSheetButton Create(string text, ICommand command)
        {
            return new ActionSheetButton(ActionSheetButtonType.Other, text, command);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static ActionSheetButton CreateCancel(string text, ICommand command)
        {
            return new ActionSheetButton(ActionSheetButtonType.Cancel, text, command);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="text"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static ActionSheetButton CreateDestroy(string text, ICommand command)
        {
            return new ActionSheetButton(ActionSheetButtonType.Destroy, text, command);
        }
    }
}
