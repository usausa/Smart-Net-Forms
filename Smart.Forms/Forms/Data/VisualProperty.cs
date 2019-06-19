namespace Smart.Forms.Data
{
    using Xamarin.Forms;

    public static class VisualProperty
    {
        public static readonly BindableProperty StateProperty = BindableProperty.CreateAttached(
            "State",
            typeof(string),
            typeof(VisualProperty),
            null,
            propertyChanged: HandlePropertyChanged);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static string GetState(BindableObject view) => (string)view.GetValue(StateProperty);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static void SetState(BindableObject view, string value) => view.SetValue(StateProperty, value);

        private static void HandlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            VisualStateManager.GoToState((VisualElement)bindable, (string)newValue);
        }
    }
}
