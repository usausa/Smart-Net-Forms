﻿namespace Example.FormsApp.Views
{
    using Xamarin.Forms;

    public class ShellProperty
    {
        public static readonly BindableProperty ShellControlProperty = BindableProperty.CreateAttached(
            "ShellControl",
            typeof(IShellControl),
            typeof(ShellProperty),
            null);

        public static IShellControl GetShellControl(BindableObject view)
        {
            return (IShellControl)view.GetValue(ShellControlProperty);
        }

        public static void SetShellControl(BindableObject view, IShellControl value)
        {
            view.SetValue(ShellControlProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.CreateAttached(
            "Title",
            typeof(string),
            typeof(ShellProperty),
            null,
            propertyChanged: PropertyChanged);

        public static string GetTitle(BindableObject view)
        {
            return (string)view.GetValue(TitleProperty);
        }

        public static void SetTitle(BindableObject view, string value)
        {
            view.SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty CanBackProperty = BindableProperty.CreateAttached(
            "CanBack",
            typeof(bool),
            typeof(ShellProperty),
            true,
            propertyChanged: PropertyChanged);

        public static bool GetCanBack(BindableObject view)
        {
            return (bool)view.GetValue(CanBackProperty);
        }

        public static void SetCanBack(BindableObject view, bool value)
        {
            view.SetValue(CanBackProperty, value);
        }

        public static readonly BindableProperty CanOptionProperty = BindableProperty.CreateAttached(
            "CanOption",
            typeof(bool),
            typeof(ShellProperty),
            false,
            propertyChanged: PropertyChanged);

        public static bool GetCanOption(BindableObject view)
        {
            return (bool)view.GetValue(CanOptionProperty);
        }

        public static void SetCanOption(BindableObject view, bool value)
        {
            view.SetValue(CanOptionProperty, value);
        }

        public static readonly BindableProperty Function1TextProperty = BindableProperty.CreateAttached(
            "Function1Text",
            typeof(string),
            typeof(ShellProperty),
            string.Empty,
            propertyChanged: PropertyChanged);

        public static string GetFunction1Text(BindableObject view)
        {
            return (string)view.GetValue(Function1TextProperty);
        }

        public static void SetFunction1Text(BindableObject view, string value)
        {
            view.SetValue(Function1TextProperty, value);
        }

        public static readonly BindableProperty Function2TextProperty = BindableProperty.CreateAttached(
            "Function2Text",
            typeof(string),
            typeof(ShellProperty),
            string.Empty,
            propertyChanged: PropertyChanged);

        public static string GetFunction2Text(BindableObject view)
        {
            return (string)view.GetValue(Function2TextProperty);
        }

        public static void SetFunction2Text(BindableObject view, string value)
        {
            view.SetValue(Function2TextProperty, value);
        }

        public static readonly BindableProperty Function3TextProperty = BindableProperty.CreateAttached(
            "Function3Text",
            typeof(string),
            typeof(ShellProperty),
            string.Empty,
            propertyChanged: PropertyChanged);

        public static string GetFunction3Text(BindableObject view)
        {
            return (string)view.GetValue(Function3TextProperty);
        }

        public static void SetFunction3Text(BindableObject view, string value)
        {
            view.SetValue(Function3TextProperty, value);
        }

        public static readonly BindableProperty Function4TextProperty = BindableProperty.CreateAttached(
            "Function4Text",
            typeof(string),
            typeof(ShellProperty),
            string.Empty,
            propertyChanged: PropertyChanged);

        public static string GetFunction4Text(BindableObject view)
        {
            return (string)view.GetValue(Function4TextProperty);
        }

        public static void SetFunction4Text(BindableObject view, string value)
        {
            view.SetValue(Function4TextProperty, value);
        }

        public static readonly BindableProperty Function1EnabledProperty = BindableProperty.CreateAttached(
            "Function1Enabled",
            typeof(bool),
            typeof(ShellProperty),
            false,
            propertyChanged: PropertyChanged);

        public static bool GetFunction1Enabled(BindableObject view)
        {
            return (bool)view.GetValue(Function1EnabledProperty);
        }

        public static void SetFunction1Enabled(BindableObject view, bool value)
        {
            view.SetValue(Function1EnabledProperty, value);
        }

        public static readonly BindableProperty Function2EnabledProperty = BindableProperty.CreateAttached(
            "Function2Enabled",
            typeof(bool),
            typeof(ShellProperty),
            false,
            propertyChanged: PropertyChanged);

        public static bool GetFunction2Enabled(BindableObject view)
        {
            return (bool)view.GetValue(Function2EnabledProperty);
        }

        public static void SetFunction2Enabled(BindableObject view, bool value)
        {
            view.SetValue(Function2EnabledProperty, value);
        }

        public static readonly BindableProperty Function3EnabledProperty = BindableProperty.CreateAttached(
            "Function3Enabled",
            typeof(bool),
            typeof(ShellProperty),
            false,
            propertyChanged: PropertyChanged);

        public static bool GetFunction3Enabled(BindableObject view)
        {
            return (bool)view.GetValue(Function3EnabledProperty);
        }

        public static void SetFunction3Enabled(BindableObject view, bool value)
        {
            view.SetValue(Function3EnabledProperty, value);
        }

        public static readonly BindableProperty Function4EnabledProperty = BindableProperty.CreateAttached(
            "Function4Enabled",
            typeof(bool),
            typeof(ShellProperty),
            false,
            propertyChanged: PropertyChanged);

        public static bool GetFunction4Enabled(BindableObject view)
        {
            return (bool)view.GetValue(Function4EnabledProperty);
        }

        public static void SetFunction4Enabled(BindableObject view, bool value)
        {
            view.SetValue(Function4EnabledProperty, value);
        }

        private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var parent = ((ContentView)bindable).Parent;
            if (parent == null)
            {
                return;
            }

            UpdateShellControl(parent, bindable);
        }

        public static void UpdateShellControl(BindableObject parent, BindableObject child)
        {
            var shellControl = GetShellControl(parent);
            if (shellControl != null)
            {
                shellControl.Title.Value = GetTitle(child);
                shellControl.CanBack.Value = GetCanBack(child);
                shellControl.CanOption.Value = GetCanOption(child);
                shellControl.Function1Text.Value = GetFunction1Text(child);
                shellControl.Function2Text.Value = GetFunction2Text(child);
                shellControl.Function3Text.Value = GetFunction3Text(child);
                shellControl.Function4Text.Value = GetFunction4Text(child);
                shellControl.Function1Enabled.Value = GetFunction1Enabled(child);
                shellControl.Function2Enabled.Value = GetFunction2Enabled(child);
                shellControl.Function3Enabled.Value = GetFunction3Enabled(child);
                shellControl.Function4Enabled.Value = GetFunction4Enabled(child);
            }
        }
    }
}