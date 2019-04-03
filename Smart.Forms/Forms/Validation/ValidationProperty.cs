namespace Smart.Forms.Validation
{
    using Xamarin.Forms;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces", Justification = "Ignore")]
    public static class ValidationProperty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
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
