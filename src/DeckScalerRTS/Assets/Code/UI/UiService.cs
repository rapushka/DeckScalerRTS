using UnityEngine;

namespace DeckScaler
{
    public interface IUiService : IService
    {
        RectTransform Canvas { get; }
    }

    public class UiService : IUiService
    {
        public UiService(Canvas canvas)
        {
            Canvas = (RectTransform)canvas.transform;
        }

        public RectTransform Canvas { get; }
    }
}