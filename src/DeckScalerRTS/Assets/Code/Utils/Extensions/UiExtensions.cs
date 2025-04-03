using UnityEngine.UI;

namespace DeckScaler
{
    public static class UiExtensions
    {
        public static Image SetAlpha(this Image @this, float alpha)
        {
            var color = @this.color;
            color.a = alpha;
            @this.color = color;

            return @this;
        }
    }
}