using UnityEngine;

namespace DeckScaler
{
    public interface IUiService : IService
    {
        RectTransform CanvasTransform { get; }

        Vector2 GetPositionOnCanvas(Vector2 screenPosition, RectTransform parent = null);
    }

    public class UiService : IUiService
    {
        private readonly Canvas _canvas;

        public UiService(Canvas canvas)
        {
            _canvas = canvas;
            CanvasTransform = (RectTransform)canvas.transform;
        }

        public RectTransform CanvasTransform { get; }

        public Vector2 GetPositionOnCanvas(Vector2 screenPosition, RectTransform parent = null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parent ?? CanvasTransform,
                screenPosition,
                _canvas.worldCamera,
                out var localPoint
            );
            return localPoint;
        }
    }
}