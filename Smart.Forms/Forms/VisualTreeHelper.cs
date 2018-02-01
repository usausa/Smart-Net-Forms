namespace Smart.Forms
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    using Xamarin.Forms;

    public static class VisualTreeHelper
    {
        public static T GetParent<T>(Element element)
            where T : Element
        {
            while (true)
            {
                if (element is T variable)
                {
                    return variable;
                }

                if (element.Parent == null)
                {
                    return default;
                }

                element = element.Parent;
            }
        }

        public static IEnumerable<T> GetChildren<T>(Element parent)
            where T : Element
        {
            // Content
            var contentProperty = parent.GetType().GetRuntimeProperty("Content");
            if (contentProperty != null)
            {
                var value = contentProperty.GetValue(parent);
                if (value is T typedChild)
                {
                    yield return typedChild;
                }

                if (value is Element element)
                {
                    foreach (var child in GetChildren<T>(element))
                    {
                        yield return child;
                    }
                }

                yield break;
            }

            // Children
            var childrenProperty = parent.GetType().GetRuntimeProperty("Children");
            if (childrenProperty != null)
            {
                if (childrenProperty.GetValue(parent) is IEnumerable children)
                {
                    foreach (var child in children)
                    {
                        if (child is T typedChild)
                        {
                            yield return typedChild;
                        }

                        if (child is Element element)
                        {
                            foreach (var elementChild in GetChildren<T>(element))
                            {
                                yield return elementChild;
                            }
                        }
                    }
                }
            }
        }
    }
}
