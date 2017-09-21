﻿namespace Smart.Forms.Internal
{
    using System;

    internal static class Actions
    {
        public static Func<bool> True { get; } = () => true;
    }

    internal static class Actions<T>
    {
        public static Func<T, bool> True { get; } = x => true;
    }
}
