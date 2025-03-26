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

        public Transform Root => _itemsRoot;

        public void CreateInventory(Entity<GameScope> unit)
        {
            foreach (var slot in InventoryUtils.GetSlotsInOrder(unit.ID()))
            {
                var itemView = CreateSlotView(slot);

                var index = slot.Get<InventorySlotIndex, int>();
                _slotsMap.Add(index, itemView);
            }
        }

        public void UpdateView(Entity<GameScope> unit)
        {
            foreach (var slot in InventoryUtils.GetInventory(unit.ID()))
            {
                var index = slot.Get<InventorySlotIndex, int>();
                _slotsMap[index].UpdateView(slot);
            }
        }

        public void Clear()
        {
            _slotsMap.DestroyValues();
        }

        private InventoryItemUI CreateSlotView(Entity<GameScope> slot)
        {
            var itemView = Instantiate(_itemPrefab, _itemsRoot);
            itemView.UpdateView(slot);

            return itemView;
        }
    }
}