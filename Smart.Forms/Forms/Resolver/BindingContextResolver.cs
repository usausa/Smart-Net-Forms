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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static Type GetType(BindableObject obj)
        {
            return (Type)obj.GetValue(TypeProperty);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static void SetType(BindableObject obj, Type value)
        {
            obj.SetValue(TypeProperty, value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
        public static bool GetDisposeOnChanged(BindableObject obj)
        {
            return (bool)obj.GetValue(DisposeOnChangedProperty);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Ignore")]
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

            bindable.BindingContext = newValue is not null ? ResolveProvider.Default.Resolve((Type)newValue) : null;
        }
    }
}
