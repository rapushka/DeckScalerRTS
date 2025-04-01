using UnityEngine;

namespace DeckScaler
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;
        [SerializeField] private RectTransform _draggingContainer;

        public Transform     Root              => _itemsRoot;
        public RectTransform DraggingContainer => _draggingContainer;
    }
}