namespace Smart.Forms.Interactivity
{
    using System.Windows.Input;

    using Xamarin.Forms;

    public sealed class ListViewSelectedToCommandBehavior : BehaviorBase<ListView>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ListViewSelectedToCommandBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.ItemSelected += HandleItemSelected;
        }

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

            if (AssociatedObject != null)
            {
                AssociatedObject.SelectedItem = null;
            }
        }
    }
}
