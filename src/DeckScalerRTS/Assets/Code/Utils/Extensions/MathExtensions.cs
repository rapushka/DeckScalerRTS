using UnityEngine;

namespace DeckScaler
{
    public static class MathExtensions
    {
        public static float Clamp01(this float @this)
            => Mathf.Clamp01(@this);

        public static float Clamp(this float @this, float? min = null, float? max = null)
            => Mathf.Clamp(@this, min ?? @this, max ?? @this);

        public static bool Approximately(this float @this, float other)
            => Mathf.Approximately(@this, other);
    }
}