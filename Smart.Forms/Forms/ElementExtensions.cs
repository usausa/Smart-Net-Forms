namespace Smart.Forms;

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
            var parent = element.Parent;
            if (parent is null)
            {
                return null;
            }

            if (element is T variable)
            {
                return variable;
            }

            element = parent;
        }
    }

    // ------------------------------------------------------------
    // Children
    // ------------------------------------------------------------

    public static IEnumerable<T> FindChildren<T>(this Element parent)
        where T : Element
    {
        foreach (var child in parent.LogicalChildren)
        {
            if (child is T typedChild)
            {
                yield return typedChild;
            }

            foreach (var descendant in child.FindChildren<T>())
            {
                yield return descendant;
            }
        }
    }
}
