namespace Smart.Forms.Validation
{
    using System;

    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    public sealed class SetFocusToErrorElementBehavior : BehaviorBase<VisualElement>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty RequestProperty = BindableProperty.Create(
            nameof(Request),
            typeof(ValidationRequest),
            typeof(SetFocusToErrorElementBehavior),
            propertyChanged: HandleRequestPropertyChanged);

        public ValidationRequest Request
        {
            get => (ValidationRequest)GetValue(RequestProperty);
            set => SetValue(RequestProperty, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(VisualElement bindable)
        {
            if (Request != null)
            {
                Request.ValidationErrorRequested -= OnValidationErrorRequested;
            }

            base.OnDetachingFrom(bindable);
        }

        private static void HandleRequestPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SetFocusToErrorElementBehavior)bindable).HandleRequestPropertyChanged(oldValue as ValidationRequest, newValue as ValidationRequest);
        }

        private void HandleRequestPropertyChanged(ValidationRequest oldValue, ValidationRequest newValue)
        {
            if (oldValue == newValue)
            {
                return;
            }

            if (oldValue != null)
            {
                oldValue.ValidationErrorRequested -= OnValidationErrorRequested;
            }

            if (newValue != null)
            {
                newValue.ValidationErrorRequested += OnValidationErrorRequested;
            }
        }

        private void OnValidationErrorRequested(object sender, EventArgs eventArgs)
        {
            var element = FindErrorElement(AssociatedObject);
            element?.Focus();
        }

        private VisualElement FindErrorElement(VisualElement element)
        {
            if (ValidationProperty.GetHasError(element))
            {
                return element;
            }

            if (element is IViewContainer<View> layout)
            {
                foreach (var child in layout.Children)
                {
                    var find = FindErrorElement(child);
                    if (find != null)
                    {
                        return find;
                    }
                }
            }

            if (element is ContentPage page)
            {
                var find = FindErrorElement(page.Content);
                if (find != null)
                {
                    return find;
                }
            }

            if (element is ContentView view)
            {
                var find = FindErrorElement(view.Content);
                if (find != null)
                {
                    return find;
                }
            }

            return null;
        }
    }
}
