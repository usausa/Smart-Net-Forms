namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    public sealed class DataStateBehavior : BehaviorBase<VisualElement>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty BindingProperty = BindableProperty.Create(
            nameof(Binding),
            typeof(object),
            typeof(DataStateBehavior),
            propertyChanged: HandlePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(object),
            typeof(DataStateBehavior),
            propertyChanged: HandlePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ComparisonProperty = BindableProperty.Create(
            nameof(Comparison),
            typeof(IDataComparison),
            typeof(DataStateBehavior),
            Comparisons.Equal);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TrueStateProperty = BindableProperty.Create(
            nameof(TrueState),
            typeof(string),
            typeof(DataStateBehavior));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty FalseStateProperty = BindableProperty.Create(
            nameof(FalseState),
            typeof(string),
            typeof(DataStateBehavior));

        public object Binding
        {
            get => GetValue(BindingProperty);
            set => SetValue(BindingProperty, value);
        }

        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public IDataComparison Comparison
        {
            get => (IDataComparison)GetValue(ComparisonProperty);
            set => SetValue(ComparisonProperty, value);
        }

        public string TrueState
        {
            get => (string)GetValue(TrueStateProperty);
            set => SetValue(TrueStateProperty, value);
        }

        public string FalseState
        {
            get => (string)GetValue(FalseStateProperty);
            set => SetValue(FalseStateProperty, value);
        }

        private static void HandlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            ((DataStateBehavior)bindable).HandlePropertyChanged();
        }

        private void HandlePropertyChanged()
        {
            if (AssociatedObject == null)
            {
                return;
            }

            var stateName = Comparison.Eval(Binding, Value) ? TrueState : FalseState;
            VisualStateManager.GoToState(AssociatedObject, stateName);
        }
    }
}
