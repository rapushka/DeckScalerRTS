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
    }
}