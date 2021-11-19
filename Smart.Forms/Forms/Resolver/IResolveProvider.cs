namespace Smart.Forms.Resolver;

using System;

public interface IResolveProvider
{
    object? Resolve(Type type);
}
