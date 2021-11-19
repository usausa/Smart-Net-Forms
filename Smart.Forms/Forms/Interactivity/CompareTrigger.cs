namespace Smart.Forms.Interactivity;

using Smart.Forms.Expressions;

using Xamarin.Forms;

public sealed class CompareTrigger : TriggerBase<BindableObject>
{
    public static readonly BindableProperty BindingProperty = BindableProperty.Create(
        nameof(Binding),
        typeof(object),
        typeof(CompareTrigger),
        propertyChanged: HandlePropertyChanged);

    public static readonly BindableProperty ParameterProperty = BindableProperty.Create(
        nameof(Parameter),
        typeof(object),
        typeof(CompareTrigger),
        propertyChanged: HandlePropertyChanged);

    public static readonly BindableProperty ExpressionProperty = BindableProperty.Create(
        nameof(Expression),
        typeof(ICompareExpression),
        typeof(CompareTrigger),
        CompareExpressions.Equal);

    public object? Binding
    {
        get => GetValue(BindingProperty);
        set => SetValue(BindingProperty, value);
    }

    public object? Parameter
    {
        get => GetValue(ParameterProperty);
        set => SetValue(ParameterProperty, value);
    }

    public ICompareExpression? Expression
    {
        get => (ICompareExpression)GetValue(ExpressionProperty);
        set => SetValue(ExpressionProperty, value);
    }

    private static void HandlePropertyChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        if (oldValue == newValue)
        {
            return;
        }

        ((CompareTrigger)bindable).HandlePropertyChanged();
    }

    private void HandlePropertyChanged()
    {
        var expression = Expression ?? CompareExpressions.Equal;
        if (expression.Eval(Binding, Parameter))
        {
            InvokeActions(null);
        }
    }
}
