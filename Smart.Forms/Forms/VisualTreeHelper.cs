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

        public static IEnumerable<T> GetChildren<T>(Element element)
            where T : Element
        {
            // Content
            var contentProperty = element.GetType().GetRuntimeProperty("Content");
            if (contentProperty != null)
            {
                if (contentProperty.GetValue(element) is Element content)
                {
                    if (content is T typedChild)
                    {
                        yield return typedChild;
                    }

                    foreach (var child in GetChildren<T>(content))
                    {
                        yield return child;
                    }
                }

                yield break;
            }

            // Children
            var childrenProperty = element.GetType().GetRuntimeProperty("Children");
            if (childrenProperty != null)
            {
                if (childrenProperty.GetValue(element) is IEnumerable children)
                {
                    foreach (var child in children)
                    {
                        if (child is T typedChild)
                        {
                            yield return typedChild;
                        }

                        if (child is Element childElement1)
                        {
                            foreach (var childChild in GetChildren<T>(childElement1))
                            {
                                yield return childChild;
                            }
                        }
                    }
                }
            }
        }
    }
}
