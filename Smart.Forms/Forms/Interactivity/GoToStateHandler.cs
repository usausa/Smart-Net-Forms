namespace Smart.Forms.Interactivity
{
    using System;

    using Xamarin.Forms;

    public sealed class GoToStateHandler : ActionHandler<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty StateNameProperty = BindableProperty.Create(
            nameof(StateName),
            typeof(string),
            typeof(GoToStateHandler));

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(GoToStateHandler));

        /// <summary>
        ///
        /// </summary>
        public string StateName
        {
            get => (string)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        public VisualElement Target
        {
            get => (VisualElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="associatedObject"></param>
        /// <param name="parameter"></param>
        protected override void Invoke(BindableObject associatedObject, object parameter)
        {
            if (String.IsNullOrEmpty(StateName))
            {
                return;
            }

            var element = Target ?? (associatedObject as VisualElement);
            if (element != null)
            {
                VisualStateManager.GoToState(element, StateName);
            }
        }
    }
}
