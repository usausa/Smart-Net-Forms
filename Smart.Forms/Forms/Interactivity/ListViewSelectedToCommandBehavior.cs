namespace Smart.Forms.Interactivity
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public sealed class ListViewSelectedToCommandBehavior : BehaviorBase<ListView>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ListViewSelectedToCommandBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.ItemSelected += HandleItemSelected;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(ListView bindable)
        {
            bindable.ItemSelected -= HandleItemSelected;

            base.OnDetachingFrom(bindable);
        }

        private void HandleItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is null)
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
