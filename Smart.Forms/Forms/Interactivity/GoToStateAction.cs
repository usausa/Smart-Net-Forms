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
        public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
            nameof(TargetObject),
            typeof(VisualElement),
            typeof(GoToStateAction));

        public string StateName
        {
            get => (string)GetValue(TargetObjectProperty);
            set => SetValue(TargetObjectProperty, value);
        }

        public VisualElement TargetObject
        {
            get => (VisualElement)GetValue(TargetObjectProperty);
            set => SetValue(TargetObjectProperty, value);
        }

        protected override void Invoke(BindableObject associatedObject, object parameter)
        {
            if (String.IsNullOrEmpty(StateName))
            {
                return;
            }

            var element = TargetObject ?? (associatedObject as VisualElement);
            if (element != null)
            {
                VisualStateManager.GoToState(element, StateName);
            }
        }
    }
}
