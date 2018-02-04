namespace Smart.Forms.Validation
{
    using System;

    using Smart.Forms.Interactivity;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public class SetFocusToErrorElementBehavior : BehaviorBase<VisualElement>
    {
        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty RequestProperty =
            BindableProperty.Create(nameof(Request), typeof(ValidationRequest), typeof(SetFocusToErrorElementBehavior), propertyChanged: OnRequestPropertyChanged);

        /// <summary>
        ///
        /// </summary>
        public ValidationRequest Request
        {
            get => (ValidationRequest)GetValue(RequestProperty);
            set => SetValue(RequestProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        protected override void OnDetachingFrom(VisualElement bindable)
        {
            if (Request != null)
            {
                Request.ValidationErrorRequested -= OnValidationErrorRequested;
            }

            base.OnDetachingFrom(bindable);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void OnRequestPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((SetFocusToErrorElementBehavior)bindable).OnRequestPropertyChanged(oldValue as ValidationRequest, newValue as ValidationRequest);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private void OnRequestPropertyChanged(ValidationRequest oldValue, ValidationRequest newValue)
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void OnValidationErrorRequested(object sender, EventArgs eventArgs)
        {
            var element = FindErrorElement(AssociatedObject);
            element?.Focus();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
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
