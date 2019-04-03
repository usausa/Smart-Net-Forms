namespace Smart.Forms.Markup
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("Source")]
    public sealed class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Source is null ? null : ImageSource.FromResource(Source);
        }
    }
}
