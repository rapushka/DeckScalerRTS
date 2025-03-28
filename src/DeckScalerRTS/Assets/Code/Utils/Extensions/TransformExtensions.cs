using UnityEngine;

namespace DeckScaler
{
    public static class TransformExtensions
    {
        public static void SetPosition(this Transform @this, float? x = null, float? y = null, float? z = null)
        {
            var position = @this.position;
            @this.position = new(
                x: x ?? position.x,
                y: y ?? position.y,
                z: z ?? position.z
            );
        }

        public static Transform SetupToParent(this Transform @this, Transform parent)
        {
            @this.SetParent(parent);
            return @this.Reset();
        }

        public static Transform Reset(this Transform @this)
        {
            @this.localPosition = Vector3.zero;
            @this.localRotation = Quaternion.identity;
            @this.localScale = Vector3.one;

            return @this;
        }
    }
}