namespace Smart.Forms.Interactivity;

using Xamarin.Forms;

public sealed class GoToStateAction : ActionBase<BindableObject>
{
    public static readonly BindableProperty StateNameProperty = BindableProperty.Create(
        nameof(StateName),
        typeof(string),
        typeof(GoToStateAction),
        string.Empty);

    public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
        nameof(TargetObject),
        typeof(VisualElement),
        typeof(GoToStateAction));

    public string StateName
    {
        get => (string)GetValue(StateNameProperty);
        set => SetValue(StateNameProperty, value);
    }

    public VisualElement? TargetObject
    {
        get => (VisualElement)GetValue(TargetObjectProperty);
        set => SetValue(TargetObjectProperty, value);
    }

    protected override void Invoke(BindableObject associatedObject, object? parameter)
    {
        if (String.IsNullOrEmpty(StateName))
        {
            return;
        }

        var element = TargetObject ?? (associatedObject as VisualElement);
        if (element is not null)
        {
            VisualStateManager.GoToState(element, StateName);
        }
    }
}
