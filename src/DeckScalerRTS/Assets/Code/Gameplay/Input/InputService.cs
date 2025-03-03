using UnityEngine;

namespace DeckScaler
{
    public interface IInputService : IService
    {
        bool JustClickedSelect       { get; }
        bool IsDragButtonPressed     { get; }
        bool IsDragButtonJustPressed { get; }

        Vector2 MouseScreenPosition { get; }
        Vector2 MouseMovementDelta  { get; }
    }

    public class InputService : IInputService
    {
        public bool JustClickedSelect => Input.GetMouseButtonDown(SelectClick);

        public bool IsDragButtonJustPressed => Input.GetMouseButtonDown(DragClick);

        public bool IsDragButtonPressed => Input.GetMouseButton(DragClick);

        public Vector2 MouseScreenPosition => Input.mousePosition;

        public Vector2 MouseMovementDelta => Input.mousePositionDelta;

        private static int SelectClick => (int)Constants.InputBindings.SelectClick;

        private static int DragClick => (int)Constants.InputBindings.DragClick;
    }
}