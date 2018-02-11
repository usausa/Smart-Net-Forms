namespace Smart.Forms.Resolver
{
    using System;

    using Xamarin.Forms.Xaml;

    public sealed class ResolveExtension : IMarkupExtension
    {
        public Type Type { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return ResolveProvider.Default.Resolve(Type);
        }
    }
}
