namespace Smart.Forms.Interactivity
{
    using System;
    using System.Globalization;

    public interface IDataComparison
    {
        bool Eval(object left, object right);
    }

    internal abstract class DataComparison : IDataComparison
    {
        public bool Eval(object left, object right)
        {
            if ((left is IComparable comparable) && (right != null))
            {
                object convertedValue;
                try
                {
                    convertedValue = Convert.ChangeType(right, left.GetType(), CultureInfo.CurrentCulture);
                }
                catch
                {
                    convertedValue = null;
                }

                if (convertedValue == null)
                {
                    return WhenRightIsNull();
                }

                return EvalComparison(comparable.CompareTo(convertedValue));
            }

            return WhenNotComparable(left, right);
        }

        protected abstract bool WhenRightIsNull();

        protected abstract bool EvalComparison(int comparison);

        protected abstract bool WhenNotComparable(object left, object right);
    }

    internal sealed class EqualDataComparison : DataComparison
    {
        protected override bool WhenRightIsNull() => false;

        protected override bool EvalComparison(int comparison) => comparison == 0;

        protected override bool WhenNotComparable(object left, object right) => Equals(left, right);
    }

    internal sealed class NotEqualDataComparison : DataComparison
    {
        protected override bool WhenRightIsNull() => true;

        protected override bool EvalComparison(int comparison) => comparison != 0;

        protected override bool WhenNotComparable(object left, object right) => !Equals(left, right);
    }

    internal sealed class LessThanDataComparison : DataComparison
    {
        protected override bool WhenRightIsNull() => false;

        protected override bool EvalComparison(int comparison) => comparison < 0;

        protected override bool WhenNotComparable(object left, object right) => false;
    }

    internal sealed class LessThanOrEqualDataComparison : DataComparison
    {
        protected override bool WhenRightIsNull() => false;

        protected override bool EvalComparison(int comparison) => comparison <= 0;

        protected override bool WhenNotComparable(object left, object right) => false;
    }

    internal sealed class GreaterThanDataComparison : DataComparison
    {
        protected override bool WhenRightIsNull() => false;

        protected override bool EvalComparison(int comparison) => comparison > 0;

        protected override bool WhenNotComparable(object left, object right) => false;
    }

    internal sealed class GreaterThanOrEqualDataComparison : DataComparison
    {
        protected override bool WhenRightIsNull() => false;

        protected override bool EvalComparison(int comparison) => comparison >= 0;

        protected override bool WhenNotComparable(object left, object right) => false;
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
