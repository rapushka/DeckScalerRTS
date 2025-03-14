using System;
using System.Collections.Generic;

namespace DeckScaler
{
    public static class ListExtensions
    {
        public static void RemoveWhere<T>(this List<T> @this, Func<T, bool> predicate)
        {
            for (var i = @this.Count - 1; i >= 0; i--)
            {
                if (predicate.Invoke(@this[i]))
                    @this.RemoveAt(i);
            }
        }

        public static T[] AsSingleItemArray<T>(this T @this) => new[] { @this };
    }
}