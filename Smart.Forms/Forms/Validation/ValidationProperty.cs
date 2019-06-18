namespace Smart.Forms.Validation
{
    using Xamarin.Forms;

    public static class ValidationProperty
    {
        public static readonly BindableProperty HasErrorProperty = BindableProperty.CreateAttached(
            "HasError",
            typeof(bool),
            typeof(ValidationProperty),
            false);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static bool GetHasError(BindableObject view)
        {
            return (bool)view.GetValue(HasErrorProperty);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static void SetHasError(BindableObject view, bool value)
        {
            view.SetValue(HasErrorProperty, value);
        }
    }
}
