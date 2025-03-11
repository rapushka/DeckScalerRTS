using System;
using System.Collections.Generic;

namespace DeckScaler
{
    public static class StringExtensions
    {
        public static string Remove(this string @this, string value)
            => @this.Remove(@this.IndexOf(value, StringComparison.Ordinal), value.Length);

        public static bool IsEmpty(this string @this) => string.IsNullOrWhiteSpace(@this);

#region Format
        public static string Format(this string format, object arg0)
            => string.Format(format, arg0);

        public static string Format(this string format, object arg0, object arg1)
            => string.Format(format, arg0, arg1);

        public static string Format(this string format, object arg0, object arg1, object arg2)
            => string.Format(format, arg0, arg1, arg2);

        public static string Format(this string format, params object[] args)
            => string.Format(format, args);
#endregion

        public static string JoinToString<T>(this IEnumerable<T> @this, string separator = ", ")
            => string.Join(separator, @this);
    }
}