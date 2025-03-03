using UnityEngine;

namespace DeckScaler
{
    public interface IInputService : IService
    {
        bool    JustClickedSelect   { get; }
        Vector3 MouseScreenPosition { get; }
        Vector3 MouseMovementDelta  { get; }
    }

    public class InputService : IInputService
    {
        public bool JustClickedSelect => Input.GetMouseButtonDown((int)Constants.InputBindings.SelectClick);

        public Vector3 MouseScreenPosition => Input.mousePosition;

        public Vector3 MouseMovementDelta => Input.mousePositionDelta;
    }
}