namespace Smart.Forms.Interactivity
{
    using System.Windows.Input;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class ItemSelectedToCommandBehavior : BehaviorBase<ListView>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ItemSelectedToCommandBehavior));

        /// <summary>
        ///
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.ItemSelected += HandleItemSelected;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.ItemSelected -= HandleItemSelected;

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            if (Command?.CanExecute(e.SelectedItem) ?? false)
            {
                Command.Execute(e.SelectedItem);
            }

            AssociatedObject.SelectedItem = null;
        }
    }
}
