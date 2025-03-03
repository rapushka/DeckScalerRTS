using UnityEngine;

namespace DeckScaler
{
    public interface IInputService : IService
    {
        bool JustClickedSelect       { get; }
        bool JustClickedOrder        { get; }
        bool IsDragButtonPressed     { get; }
        bool IsDragButtonJustPressed { get; }

        Vector2 MouseScreenPosition { get; }
    }

    public class InputService : IInputService
    {
        public bool JustClickedSelect => Input.GetMouseButtonDown(SelectClick);

        public bool JustClickedOrder => Input.GetMouseButtonDown(OrderClick);

        public bool IsDragButtonJustPressed => Input.GetMouseButtonDown(DragCameraClick);

        public bool IsDragButtonPressed => Input.GetMouseButton(DragCameraClick);

        public Vector2 MouseScreenPosition => Input.mousePosition;

        private static int SelectClick => (int)Constants.InputBindings.SelectClick;

        private static int OrderClick => (int)Constants.InputBindings.OrderClick;

        private static int DragCameraClick => (int)Constants.InputBindings.DragClick;
    }
}