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
            propertyChanged: OnPropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(object),
            typeof(DataChangedTrigger),
            propertyChanged: OnPropertyChanged);

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

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            ((DataChangedTrigger)bindable).OnPropertyChanged();
        }

        private void OnPropertyChanged()
        {
            if ((Binding == Value) || ((Binding != null) && Binding.Equals(Value)))
            {
                InvokeActions(Value);
            }
        }
    }
}
