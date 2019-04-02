namespace Smart.Forms.Resolver
{
    using System;

    using Xamarin.Forms;

    public static class BindingContextResolver
    {
        public static readonly BindableProperty TypeProperty = BindableProperty.CreateAttached(
            "Type",
            typeof(Type),
            typeof(BindingContextResolver),
            null,
            propertyChanged: HandleTypePropertyChanged);

        public static readonly BindableProperty DisposeOnChangedProperty = BindableProperty.CreateAttached(
            "DisposeOnChanged",
            typeof(bool),
            typeof(BindingContextResolver),
            true);

        public static Type GetType(BindableObject obj)
        {
            return (Type)obj.GetValue(TypeProperty);
        }

        public static void SetType(BindableObject obj, Type value)
        {
            obj.SetValue(TypeProperty, value);
        }

        public static bool GetDisposeOnChanged(BindableObject obj)
        {
            return (bool)obj.GetValue(DisposeOnChangedProperty);
        }

        public static void SetDisposeOnChanged(BindableObject obj, bool value)
        {
            obj.SetValue(DisposeOnChangedProperty, value);
        }

        private static void HandleTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable.BindingContext is IDisposable disposable && GetDisposeOnChanged(bindable))
            {
                disposable.Dispose();
            }

            bindable.BindingContext = newValue != null ? ResolveProvider.Default.Resolve((Type)newValue) : null;
        }
    }
}
