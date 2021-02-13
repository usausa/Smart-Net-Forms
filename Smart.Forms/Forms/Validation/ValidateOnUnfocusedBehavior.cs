namespace Smart.Forms.Validation
{
    using System.Windows.Input;

    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    public sealed class ValidateOnUnfocusedBehavior : BehaviorBase<VisualElement>
    {
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(IValidatable),
            typeof(ValidateOnUnfocusedBehavior));

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ValidateOnUnfocusedBehavior));

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(ValidateOnUnfocusedBehavior));

        public IValidatable Target
        {
            get => (IValidatable)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Unfocused += OnUnfocused;
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            bindable.Unfocused -= OnUnfocused;

            base.OnDetachingFrom(bindable);
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            Target?.Validate();

            if ((Command is not null) && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }
    }
}
