namespace Smart.Forms.Markup
{
    using System;
    using System.Text.RegularExpressions;

    using Smart.Forms.Data;

    using Xamarin.Forms.Xaml;

    public sealed class TextReplaceExtension : IMarkupExtension<TextReplaceConverter>
    {
        public string Pattern { get; set; }

        public string Replacement { get; set; }

        public RegexOptions Options { get; set; }

        public bool ReplaceAll { get; set; } = true;

        public TextReplaceConverter ProvideValue(IServiceProvider serviceProvider) =>
            new() { Pattern = Pattern, Replacement = Replacement, Options = Options, ReplaceAll = ReplaceAll };

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
