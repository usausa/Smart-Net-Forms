namespace Smart.Forms.Internal;

internal static class Functions
{
    public static Func<bool> True { get; } = () => true;
}

internal static class Functions<T>
{
    public static Func<T, bool> True { get; } = _ => true;
}
