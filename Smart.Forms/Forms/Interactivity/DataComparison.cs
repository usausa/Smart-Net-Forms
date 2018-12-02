namespace Smart.Forms.Interactivity
{
    using System;

    public interface IDataComparison
    {
        bool Eval(object left, object right);
    }

    internal sealed class EqualDataComparison : IDataComparison
    {
        public bool Eval(object left, object right)
        {
            return left.Equals(right);
        }
    }

    internal sealed class NotEqualDataComparison : IDataComparison
    {
        public bool Eval(object left, object right)
        {
            return !left.Equals(right);
        }
    }

    internal sealed class LessThanDataComparison : IDataComparison
    {
        public bool Eval(object left, object right)
        {
            var leftComparable = left as IComparable;
            var rightComparable = right as IComparable;
            if ((leftComparable == null) || (rightComparable == null))
            {
                return false;
            }

            var comparison = leftComparable.CompareTo(rightComparable);
            return comparison < 0;
        }
    }

    internal sealed class LessThanOrEqualDataComparison : IDataComparison
    {
        public bool Eval(object left, object right)
        {
            var leftComparable = left as IComparable;
            var rightComparable = right as IComparable;
            if ((leftComparable == null) || (rightComparable == null))
            {
                return false;
            }

            var comparison = leftComparable.CompareTo(rightComparable);
            return comparison <= 0;
        }
    }

    internal sealed class GreaterThanDataComparison : IDataComparison
    {
        public bool Eval(object left, object right)
        {
            var leftComparable = left as IComparable;
            var rightComparable = right as IComparable;
            if ((leftComparable == null) || (rightComparable == null))
            {
                return false;
            }

            var comparison = leftComparable.CompareTo(rightComparable);
            return comparison > 0;
        }
    }

    internal sealed class GreaterThanOrEqualDataComparison : IDataComparison
    {
        public bool Eval(object left, object right)
        {
            var leftComparable = left as IComparable;
            var rightComparable = right as IComparable;
            if ((leftComparable == null) || (rightComparable == null))
            {
                return false;
            }

            var comparison = leftComparable.CompareTo(rightComparable);
            return comparison >= 0;
        }
    }

    public static class Comparisons
    {
        public static IDataComparison Equal { get; } = new EqualDataComparison();

        public static IDataComparison NotEqual { get; } = new NotEqualDataComparison();

        public static IDataComparison LessThan { get; } = new LessThanDataComparison();

        public static IDataComparison LessThanOrEqual { get; } = new LessThanOrEqualDataComparison();

        public static IDataComparison GreaterThan { get; } = new GreaterThanDataComparison();

        public static IDataComparison GreaterThanOrEqual { get; } = new GreaterThanOrEqualDataComparison();
    }
}
