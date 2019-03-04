﻿namespace Smart.Forms.Expressions
{
    using System;
    using System.Globalization;

    public static class CompareExpressions
    {
        public static ICompareExpression Equal { get; } = new EqualExpression();

        public static ICompareExpression NotEqual { get; } = new NotEqualExpression();

        public static ICompareExpression LessThan { get; } = new LessThanExpression();

        public static ICompareExpression LessThanOrEqual { get; } = new LessThanOrEqualExpression();

        public static ICompareExpression GreaterThan { get; } = new GreaterThanExpression();

        public static ICompareExpression GreaterThanOrEqual { get; } = new GreaterThanOrEqualExpression();

        private abstract class CompareExpression : ICompareExpression
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

        private sealed class EqualExpression : CompareExpression
        {
            protected override bool WhenRightIsNull() => false;

            protected override bool EvalComparison(int comparison) => comparison == 0;

            protected override bool WhenNotComparable(object left, object right) => Equals(left, right);
        }

        private sealed class NotEqualExpression : CompareExpression
        {
            protected override bool WhenRightIsNull() => true;

            protected override bool EvalComparison(int comparison) => comparison != 0;

            protected override bool WhenNotComparable(object left, object right) => !Equals(left, right);
        }

        private sealed class LessThanExpression : CompareExpression
        {
            protected override bool WhenRightIsNull() => false;

            protected override bool EvalComparison(int comparison) => comparison < 0;

            protected override bool WhenNotComparable(object left, object right) => false;
        }

        private sealed class LessThanOrEqualExpression : CompareExpression
        {
            protected override bool WhenRightIsNull() => false;

            protected override bool EvalComparison(int comparison) => comparison <= 0;

            protected override bool WhenNotComparable(object left, object right) => false;
        }

        private sealed class GreaterThanExpression : CompareExpression
        {
            protected override bool WhenRightIsNull() => false;

            protected override bool EvalComparison(int comparison) => comparison > 0;

            protected override bool WhenNotComparable(object left, object right) => false;
        }

        private sealed class GreaterThanOrEqualExpression : CompareExpression
        {
            protected override bool WhenRightIsNull() => false;

            protected override bool EvalComparison(int comparison) => comparison >= 0;

            protected override bool WhenNotComparable(object left, object right) => false;
        }
    }
}