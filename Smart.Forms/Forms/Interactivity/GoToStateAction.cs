namespace Smart.Forms.Interactivity
{
    using System;

    using Xamarin.Forms;

    public sealed class GoToStateAction : ActionBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty StateNameProperty = BindableProperty.Create(
            nameof(StateName),
            typeof(string),
            typeof(GoToStateAction));

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetProperty = BindableProperty.Create(
            nameof(Target),
            typeof(VisualElement),
            typeof(GoToStateAction));

        public string StateName
        {
            get => (string)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        public VisualElement Target
        {
            get => (VisualElement)GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

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
