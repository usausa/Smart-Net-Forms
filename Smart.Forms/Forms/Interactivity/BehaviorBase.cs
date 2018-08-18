namespace Smart.Forms.Interactivity
{
    using System;

    using Xamarin.Forms;

    public abstract class BehaviorBase<T> : Behavior<T>
        where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += HandleBindingContextChanged;
        }

        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.BindingContextChanged -= HandleBindingContextChanged;
            BindingContext = null;
        }

        private void HandleBindingContextChanged(object sender, EventArgs eventArgs)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
