using System.Collections.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;
        [SerializeField] private InventoryItemUI _itemPrefab;

        private readonly List<InventoryItemUI> _items = new();

        public void Add(ItemIDRef itemID)
        {
            var itemView = Instantiate(_itemPrefab, _itemsRoot);
            itemView.Initialize(itemID);

            _items.Add(itemView);
        }

        public void Clear()
        {
            _items.DestroyAll();
        }
    }
}