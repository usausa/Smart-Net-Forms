namespace Smart
{
    using Xamarin.Forms;

    public static class ElementExtensions
    {
        public static Page GetPage(this Element element)
        {
            while (element != null)
            {
                if (element is Page page)
                {
                    return page;
                }

                element = element.Parent;
            }

            return null;
        }
    }
}
