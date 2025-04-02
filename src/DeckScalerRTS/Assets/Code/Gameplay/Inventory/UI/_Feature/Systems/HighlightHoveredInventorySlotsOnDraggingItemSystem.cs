using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class HighlightHoveredInventorySlotsOnDraggingItemSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggedItems
            = GroupBuilder<UiScope>
                .With<UiOfItem>()
                .And<Dragging>()
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
                slot.Is<Highlight>(slot.Is<HoveredByMouse>());
            }
        }
    }
}