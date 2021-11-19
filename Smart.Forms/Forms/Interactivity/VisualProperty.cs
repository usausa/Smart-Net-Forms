namespace Smart.Forms.Interactivity;

using Xamarin.Forms;

public static class VisualProperty
{
    public static readonly BindableProperty StateProperty = BindableProperty.CreateAttached(
        "State",
        typeof(string),
        typeof(VisualProperty),
        string.Empty,
        propertyChanged: HandlePropertyChanged);

    public static string GetState(BindableObject view) => (string)view.GetValue(StateProperty);

    public static void SetState(BindableObject view, string value) => view.SetValue(StateProperty, value);

    private static void HandlePropertyChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        VisualStateManager.GoToState((VisualElement)bindable, (string?)newValue);
    }
}
