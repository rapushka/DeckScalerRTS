using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class MoveDraggingItemSlotsBackOnDroppedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggingSlots
            = GroupBuilder<UiScope>
                .With<InventoryItemSlotUiView>()
                .And<Dropped>()
                .And<InitUiParent>()
                .Build();

        public void Execute()
        {
            foreach (var slot in _draggingSlots)
            {
                var initParent = slot.Get<InitUiParent>().Value;
                slot.Set<UiParent, RectTransform>(initParent);
            }
        }
    }
}