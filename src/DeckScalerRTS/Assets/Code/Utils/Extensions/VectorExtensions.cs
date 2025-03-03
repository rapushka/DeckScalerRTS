using UnityEngine;

namespace DeckScaler
{
    public static class VectorExtensions
    {
        public static Vector3 Extend(this Vector2 @this, float z = 0f) => new(@this.x, @this.y, z);

        public static Vector2 Truncate(this Vector3 @this) => new(@this.x, @this.y);

        public static float DistanceTo(this Vector2 @this, Vector2 other) => Vector2.Distance(@this, other);
    }
}