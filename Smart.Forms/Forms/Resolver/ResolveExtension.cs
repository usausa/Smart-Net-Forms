namespace Smart.Forms.Resolver;

using System;
using System.Diagnostics.CodeAnalysis;

using Xamarin.Forms.Xaml;

public sealed class ResolveExtension : IMarkupExtension
{
    [AllowNull]
    public Type Type { get; set; }

    public object? ProvideValue(IServiceProvider serviceProvider) => ResolveProvider.Default.Resolve(Type);
}
