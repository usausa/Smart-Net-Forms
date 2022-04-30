namespace Smart.Forms.Resolver;

public interface IResolveProvider
{
    object? Resolve(Type type);
}
