namespace Smart.Forms.Components
{
    using System.Windows.Input;

    public sealed class ActionSheetButton
    {
        public ActionSheetButtonType ButtonType { get; }

        public string Text { get; }

        public ICommand Command { get; }

        private ActionSheetButton(ActionSheetButtonType buttonType, string text, ICommand command)
        {
            ButtonType = buttonType;
            Text = text;
            Command = command;
        }

        public static ActionSheetButton Create(string text, ICommand command)
        {
            return new ActionSheetButton(ActionSheetButtonType.Other, text, command);
        }

        public static ActionSheetButton CreateCancel(string text, ICommand command)
        {
            return new ActionSheetButton(ActionSheetButtonType.Cancel, text, command);
        }

        public static ActionSheetButton CreateDestroy(string text, ICommand command)
        {
            return new ActionSheetButton(ActionSheetButtonType.Destroy, text, command);
        }
    }
}
