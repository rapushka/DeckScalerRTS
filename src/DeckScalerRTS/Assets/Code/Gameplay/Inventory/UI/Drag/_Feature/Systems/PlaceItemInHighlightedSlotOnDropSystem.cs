using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class PlaceItemInHighlightedSlotOnDropSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggedItems
            = GroupBuilder<UiScope>
                .With<UiOfItem>()
                .And<Dropped>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _highlightedSlots
            = GroupBuilder<UiScope>
                .With<UiOfInventorySlot>()
                .And<Highlight>()
                .Build();

        public void Execute()
        {
            foreach (var itemUI in _draggedItems)
            foreach (var slotUI in _highlightedSlots)
            {
                var itemID = itemUI.Get<UiOfItem>().Value;
                var slotID = slotUI.Get<UiOfInventorySlot>().Value;

                InventoryUtils.ReparentItemToSlot(itemID, slotID);
            }
        }
    }
}