using UnityEngine;

namespace DeckScaler
{
    public interface IInputService : IService
    {
        bool SelectJustClicked { get; }
    }

    public class InputService : IInputService
    {
        public bool SelectJustClicked => Input.GetMouseButtonDown((int)Constants.InputBindings.SelectClick);
    }
}