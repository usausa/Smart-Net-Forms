namespace Smart.Forms.Validation;

using Xamarin.Forms;

public static class ValidationProperty
{
    public static readonly BindableProperty HasErrorProperty = BindableProperty.CreateAttached(
        "HasError",
        typeof(bool),
        typeof(ValidationProperty),
        false);

    public static bool GetHasError(BindableObject view) => (bool)view.GetValue(HasErrorProperty);

    public static void SetHasError(BindableObject view, bool value) => view.SetValue(HasErrorProperty, value);
}
