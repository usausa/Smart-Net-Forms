namespace Smart.Forms.Validation
{
    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class ClearErrorOnFocusedBehavior : BehaviorBase<Entry>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty =
            BindableProperty.Create(nameof(Target), typeof(IValidity), typeof(ClearErrorOnFocusedBehavior));

        /// <summary>
        ///
        /// </summary>
        public IValidity Target
        {
            get => (IValidity)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Focused += OnFocused;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.Focused -= OnFocused;

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFocused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused && (Target != null))
            {
                Target.HasError = false;
            }
        }
    }
}
