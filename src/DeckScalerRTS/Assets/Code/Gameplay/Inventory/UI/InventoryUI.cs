using UnityEngine;

namespace DeckScaler
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;
        [SerializeField] private Transform _draggingContainer;

        public Transform Root         => _itemsRoot;
        public Transform DraggingContainer => _draggingContainer;
    }
}