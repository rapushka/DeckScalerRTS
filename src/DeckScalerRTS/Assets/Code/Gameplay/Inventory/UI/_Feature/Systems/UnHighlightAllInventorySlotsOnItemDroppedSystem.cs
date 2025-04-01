using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UnHighlightAllInventorySlotsOnItemDroppedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggedItems
            = GroupBuilder<UiScope>
                .With<ItemUI>()
                .And<Dropped>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _hoveredSlots
            = GroupBuilder<UiScope>
                .With<UiOfInventorySlot>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _draggedItems)
            foreach (var slot in _hoveredSlots)
            {
                slot.Is<Highlight>(false);
            }
        }
    }
}