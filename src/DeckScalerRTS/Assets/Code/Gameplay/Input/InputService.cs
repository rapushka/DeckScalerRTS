using UnityEngine;

namespace DeckScaler
{
    public interface IInputService : IService
    {
        bool JustClickedSelect       { get; }
        bool IsDragButtonPressed     { get; }
        bool IsDragButtonJustPressed { get; }

        Vector2 MouseScreenPosition { get; }
    }

    public class InputService : IInputService
    {
        public bool JustClickedSelect => Input.GetMouseButtonDown(SelectClick);

        public bool IsDragButtonJustPressed => Input.GetMouseButtonDown(DragClick);

        public bool IsDragButtonPressed => Input.GetMouseButton(DragClick);

        public Vector2 MouseScreenPosition => Input.mousePosition;

        private static int SelectClick => (int)Constants.InputBindings.SelectClick;

        private static int DragClick => (int)Constants.InputBindings.DragClick;
    }
}