using UnityEngine;

namespace DeckScaler
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;

        public Transform Root => _itemsRoot;
    }
}