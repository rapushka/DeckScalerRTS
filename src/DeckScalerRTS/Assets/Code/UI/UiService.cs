using UnityEngine;

namespace DeckScaler
{
    public interface IUiService : IService
    {
        RectTransform UiRoot { get; }
    }

    public class UiService : IUiService
    {
        public UiService(Canvas canvas)
        {
            UiRoot = (RectTransform)canvas.transform;
        }

        public RectTransform UiRoot { get; }
    }
}