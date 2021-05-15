namespace Smart.Forms
{
    using System.Collections.Generic;

    using Xamarin.Forms;

    public static class ElementExtensions
    {
        // ------------------------------------------------------------
        // Parent
        // ------------------------------------------------------------

        public static T? FindParent<T>(this Element element)
            where T : Element
        {
            while (true)
            {
                if (element is T variable)
                {
                    return variable;
                }

                if (element.Parent is null)
                {
                    return default;
                }

                element = element.Parent;
            }
        }

        // ------------------------------------------------------------
        // Children
        // ------------------------------------------------------------

        public static IEnumerable<T> FindChildren<T>(this Element parent)
            where T : Element
        {
            while (true)
            {
                // ContentView
                if (parent is ContentView contentView)
                {
                    var value = contentView.Content;
                    if (value is T typedChild)
                    {
                        yield return typedChild;
                    }

                    if (value is Element element)
                    {
                        parent = element;
                        continue;
                    }

                    yield break;
                }

                // Layout
                if (parent is Layout layout)
                {
                    foreach (var child in layout.Children)
                    {
                        if (child is T typedChild)
                        {
                            yield return typedChild;
                        }

                        foreach (var elementChild in FindChildren<T>(child))
                        {
                            yield return elementChild;
                        }
                    }
                }

                break;
            }
        }
    }
}
