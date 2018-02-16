namespace Smart.Forms.Resolver
{
    using System;

    using Xamarin.Forms;

    /// <summary>
    ///
    /// </summary>
    public static class BindingContextResolver
    {
        /// <summary>
        ///
        /// </summary>
        public static readonly BindableProperty TypeProperty = BindableProperty.CreateAttached(
            "Type",
            typeof(Type),
            typeof(BindingContextResolver),
            null,
            propertyChanged: HandleTypePropertyChanged);

        /// <summary>
        ///
        /// </summary>
        public static readonly BindableProperty DisposeOnChangedProperty = BindableProperty.CreateAttached(
            "DisposeOnChanged",
            typeof(bool),
            typeof(BindingContextResolver),
            true);

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Type GetType(BindableObject obj)
        {
            return (Type)obj.GetValue(TypeProperty);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetType(BindableObject obj, Type value)
        {
            obj.SetValue(TypeProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetDisposeOnChanged(BindableObject obj)
        {
            return (bool)obj.GetValue(DisposeOnChangedProperty);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetDisposeOnChanged(BindableObject obj, bool value)
        {
            obj.SetValue(DisposeOnChangedProperty, value);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
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
