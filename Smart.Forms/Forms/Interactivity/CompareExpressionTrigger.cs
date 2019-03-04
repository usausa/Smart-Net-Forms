namespace Smart.Forms.Interactivity
{
    using Smart.Forms.Expressions;

    using Xamarin.Forms;

    public sealed class CompareExpressionTrigger : TriggerBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty BindingProperty = BindableProperty.Create(
            nameof(Binding),
            typeof(object),
            typeof(CompareExpressionTrigger),
            propertyChanged: HandlePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            nameof(Value),
            typeof(object),
            typeof(CompareExpressionTrigger),
            propertyChanged: HandlePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty ExpressionProperty = BindableProperty.Create(
            nameof(Expression),
            typeof(ICompareExpression),
            typeof(CompareExpressionTrigger),
            CompareExpressions.Equal);

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

        public ICompareExpression Expression
        {
            get => (ICompareExpression)GetValue(ExpressionProperty);
            set => SetValue(ExpressionProperty, value);
        }

        private static void HandlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            ((CompareExpressionTrigger)bindable).HandlePropertyChanged();
        }

        private void HandlePropertyChanged()
        {
            if (Expression.Eval(Binding, Value))
            {
                InvokeActions(null);
            }
        }
    }
}
