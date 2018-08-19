﻿namespace Smart.Forms.Interactivity
{
    using Xamarin.Forms;

    public sealed class SetFocusAction : ActionBase<BindableObject>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "BindableProperty")]
        public static readonly BindableProperty TargetObjectProperty = BindableProperty.Create(
            nameof(TargetObject),
            typeof(VisualElement),
            typeof(SetFocusAction));

        public VisualElement TargetObject
        {
            get => (VisualElement)GetValue(TargetObjectProperty);
            set => SetValue(TargetObjectProperty, value);
        }

        protected override void Invoke(BindableObject associatedObject, object parameter)
        {
            var element = TargetObject ?? (associatedObject as VisualElement);
            element?.Focus();
        }
    }
}
