using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DisableRaycastForDraggingItemsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggedItems
            = GroupBuilder<UiScope>
                .With<ItemUI>()
                .And<RaycastTarget>()
                .Build();

        public void Execute()
        {
            foreach (var item in _draggedItems)
            {
                var isBeingDragged = item.Is<Dragging>();
                item.Set<RaycastTarget, bool>(!isBeingDragged);
            }
        }
    }
}