namespace Smart.Forms.Interactivity;

using Smart.Forms.Expressions;

using Xamarin.Forms;

public sealed class CompareStateBehavior : BehaviorBase<VisualElement>
{
    public static readonly BindableProperty BindingProperty = BindableProperty.Create(
        nameof(Binding),
        typeof(object),
        typeof(CompareStateBehavior),
        propertyChanged: HandlePropertyChanged);

    public static readonly BindableProperty ParameterProperty = BindableProperty.Create(
        nameof(Parameter),
        typeof(object),
        typeof(CompareStateBehavior),
        propertyChanged: HandlePropertyChanged);

    public static readonly BindableProperty ExpressionProperty = BindableProperty.Create(
        nameof(Expression),
        typeof(ICompareExpression),
        typeof(CompareStateBehavior),
        CompareExpressions.Equal);

    public static readonly BindableProperty TrueStateProperty = BindableProperty.Create(
        nameof(TrueState),
        typeof(string),
        typeof(CompareStateBehavior),
        string.Empty);

    public static readonly BindableProperty FalseStateProperty = BindableProperty.Create(
        nameof(FalseState),
        typeof(string),
        typeof(CompareStateBehavior),
        string.Empty);

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

    private static void HandlePropertyChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        if (oldValue == newValue)
        {
            return;
        }

        ((CompareStateBehavior)bindable).HandlePropertyChanged();
    }

    private void HandlePropertyChanged()
    {
        if (AssociatedObject is null)
        {
            return;
        }

        var expression = Expression ?? CompareExpressions.Equal;
        var stateName = expression.Eval(Binding, Parameter) ? TrueState : FalseState;
        VisualStateManager.GoToState(AssociatedObject, stateName);
    }
}
