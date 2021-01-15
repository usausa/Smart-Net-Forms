namespace Smart.Forms.Expressions
{
    public interface ICompareExpression
    {
        bool Eval(object left, object right);
    }
}
