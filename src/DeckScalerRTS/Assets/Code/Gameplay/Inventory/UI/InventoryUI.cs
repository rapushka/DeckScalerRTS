using System.Collections.Generic;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;
        [SerializeField] private InventoryItemUI _itemPrefab;

        private readonly Dictionary<int, InventoryItemUI> _slotsMap = new();

        public void CreateInventory(Entity<GameScope> unit)
        {
            foreach (var slot in InventoryUtils.GetSlotsInOrder(unit.ID()))
            {
                var itemView = slot.TryGet<ItemInSlot, EntityID>(out var itemInSlot)
                    ? AddSlotWithItem(itemInSlot.GetEntity())
                    : AddEmptySlot();

                var index = slot.Get<InventorySlotIndex, int>();
                _slotsMap.Add(index, itemView);
            }
        }

        public void Clear()
        {
            Debug.Log("clear");
            _slotsMap.DestroyValues();
        }

        private InventoryItemUI AddSlotWithItem(Entity<GameScope> item)
        {
            var itemView = Instantiate(_itemPrefab, _itemsRoot);
            itemView.SetItem(item);

            return itemView;
        }

        private InventoryItemUI AddEmptySlot()
        {
            var itemView = Instantiate(_itemPrefab, _itemsRoot);
            itemView.SetEmpty();

            return itemView;
        }
    }
}