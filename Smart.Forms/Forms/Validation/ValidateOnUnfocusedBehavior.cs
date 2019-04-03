﻿namespace Smart.Forms.Validation
{
    using System.Windows.Input;

    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    public sealed class ValidateOnUnfocusedBehavior : BehaviorBase<VisualElement>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(IValidatable),
            typeof(ValidateOnUnfocusedBehavior));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ValidateOnUnfocusedBehavior));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Unfocused += OnUnfocused;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(VisualElement bindable)
        {
            bindable.Unfocused -= OnUnfocused;

            base.OnDetachingFrom(bindable);
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            Target?.Validate();

            if ((Command != null) && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }
    }
}
