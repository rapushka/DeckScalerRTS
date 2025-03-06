using UnityEngine;

namespace DeckScaler
{
    public static class RectTransformExtensions
    {
        public static void SetSizeWithCurrentAnchors(this RectTransform @this, Vector2 value)
        {
            @this.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value.x);
            @this.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value.y);
        }
    }
}