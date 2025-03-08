using System;

namespace DeckScaler
{
    public static class StringExtensions
    {
        public static string Remove(this string @this, string value)
            => @this.Remove(@this.IndexOf(value, StringComparison.Ordinal), value.Length);

        public static bool IsEmpty(this string @this) => string.IsNullOrWhiteSpace(@this);
    }
}