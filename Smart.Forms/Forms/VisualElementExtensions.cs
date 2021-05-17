namespace Smart.Forms
{
    using Xamarin.Forms;

    public static class VisualElementExtensions
    {
        // ------------------------------------------------------------
        // Tree
        // ------------------------------------------------------------

        public static bool IsEnabledInTree(this VisualElement element)
        {
            do
            {
                if (!element.IsEnabled)
                {
                    return false;
                }

                if (element.Parent is not VisualElement visualElement)
                {
                    return false;
                }

                element = visualElement;
            }
            while (true);
        }

        public static bool IsVisibleInTree(this VisualElement element)
        {
            do
            {
                if (!element.IsVisible)
                {
                    return false;
                }

                if (element.Parent is not VisualElement visualElement)
                {
                    return false;
                }

                element = visualElement;
            }
            while (true);
        }
    }
}
