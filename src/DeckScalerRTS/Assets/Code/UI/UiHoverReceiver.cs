using UnityEngine;
using UnityEngine.EventSystems;

namespace DeckScaler
{
    public class UiHoverReceiver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private UiEntityBehaviour _entityBehaviour;

        private bool _hovered;

        private void Update()
            => _entityBehaviour.Entity?.Is<HoveredByMouse>(_hovered);

        public void OnPointerEnter(PointerEventData eventData) => _hovered = true;

        public void OnPointerExit(PointerEventData eventData) => _hovered = false;
    }
}