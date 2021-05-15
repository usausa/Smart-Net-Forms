namespace Smart.Forms.Expressions
{
    public interface IBinaryExpression
    {
        object? Eval(object? left, object? right);
    }
}
