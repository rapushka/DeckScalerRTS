using UnityEngine;

namespace DeckScaler
{
    public static class SpriteExtensions
    {
        public static void SetAlpha(this SpriteRenderer @this, float value) => @this.SetColor(a: value);

        public static void SetColor(this SpriteRenderer @this, float? r = null, float? g = null, float? b = null, float? a = null)
        {
            var color = @this.color;
            @this.color = new(r: r ?? color.r, g: g ?? color.g, b: b ?? color.b, a: a ?? color.a);
        }
    }
}