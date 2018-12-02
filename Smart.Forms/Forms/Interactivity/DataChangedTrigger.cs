namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    public sealed class DataChangedTrigger : TriggerBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty BindingProperty = BindableProperty.Create(
            nameof(Binding),
            typeof(object),
            typeof(DataChangedTrigger),
            propertyChanged: HandlePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(object),
            typeof(DataChangedTrigger),
            propertyChanged: HandlePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ComparisonProperty = BindableProperty.Create(
            nameof(Comparison),
            typeof(IDataComparison),
            typeof(DataChangedTrigger),
            Comparisons.Equal);

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

        private static void HandlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            ((DataChangedTrigger)bindable).HandlePropertyChanged();
        }

        private void HandlePropertyChanged()
        {
            if ((Binding == Value) || ((Binding != null) && Binding.Equals(Value)))
            {
                InvokeActions(Value);
            }
        }
    }
}
