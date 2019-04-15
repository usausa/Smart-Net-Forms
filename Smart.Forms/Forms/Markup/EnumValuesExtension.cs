namespace Smart.Forms.Markup
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("Type")]
    public sealed class EnumValuesExtension : IMarkupExtension
    {
        public Type Type { get; set; }

        public EnumValuesExtension(Type type)
        {
            Type = type;
        }

        public object ProvideValue(IServiceProvider serviceProvider) => Enum.GetValues(Type);
    }
}
