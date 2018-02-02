namespace Smart.Forms.Validation
{
    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces", Justification = "Ignore")]
    public static class ValidationProperties
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty HasErrorProperty =
            BindableProperty.Create("HasError", typeof(bool), typeof(ValidationProperties), false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static bool GetHasError(BindableObject view)
        {
            return (bool)view.GetValue(HasErrorProperty);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="view"></param>
        /// <param name="value"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static void SetHasError(BindableObject view, bool value)
        {
            view.SetValue(HasErrorProperty, value);
        }
    }
}
