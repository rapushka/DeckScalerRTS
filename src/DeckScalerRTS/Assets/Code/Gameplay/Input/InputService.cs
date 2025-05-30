using UnityEngine;
using UnityEngine.EventSystems;
using InputConstants = DeckScaler.Constants.InputBindings;

namespace DeckScaler
{
    public interface IInputService : IService
    {
        ButtonState SelectButton     { get; }
        ButtonState OrderButton      { get; }
        ButtonState DragCameraButton { get; }

        Vector2 MouseScreenPosition { get; }
        float   WheelScroll         { get; }

        bool IsMouseOverUI { get; }
    }

    public class InputService : IInputService, IUpdatable
    {
        private readonly Button _selectButton = new(InputConstants.SelectClick);
        private readonly Button _orderButton = new(InputConstants.OrderClick);
        private readonly Button _dragButton = new(InputConstants.DragClick);

        public ButtonState SelectButton     => _selectButton.State;
        public ButtonState OrderButton      => _orderButton.State;
        public ButtonState DragCameraButton => _dragButton.State;

        public bool IsMouseOverUI => EventSystem.current.IsPointerOverGameObject();

        public Vector2 MouseScreenPosition => Input.mousePosition;

        public float WheelScroll => Input.mouseScrollDelta.y;

        void IUpdatable.OnUpdate(float deltaTime)
        {
            _selectButton.Update(deltaTime);
            _orderButton.Update(deltaTime);
            _dragButton.Update(deltaTime);
        }

        private class Button
        {
            private readonly int _button;

            private float _holdTime;
            private bool _isHolding;

            public Button(MouseButton button)
                => _button = (int)button;

            public ButtonState State { get; private set; } = ButtonState.Unknown;

            public void Update(float deltaTime)
                => State = GetCurrentState(deltaTime);

            private ButtonState GetCurrentState(float deltaTime)
            {
                var justPressed = Input.GetMouseButtonDown(_button);
                var justReleased = Input.GetMouseButtonUp(_button);

                if (justPressed && justReleased) // ChatGPT says it's not possible, but it kinda is
                    return ButtonState.Clicked;

                if (justPressed)
                {
                    _holdTime = 0f;
                    _isHolding = true;

                    return ButtonState.JustDown;
                }

                if (justReleased)
                {
                    _isHolding = false;

                    var currentState = _holdTime < InputConstants.HoldDurationForClick
                        ? ButtonState.Clicked
                        : ButtonState.JustUp;
                    return currentState;
                }

                if (_isHolding)
                {
                    _holdTime += deltaTime;
                    return ButtonState.Down;
                }

                return ButtonState.Up;
            }
        }
    }
}