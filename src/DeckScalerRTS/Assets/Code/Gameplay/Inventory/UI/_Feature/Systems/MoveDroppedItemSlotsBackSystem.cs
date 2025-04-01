using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class MoveDroppedItemSlotsBackSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggingSlots
            = GroupBuilder<UiScope>
                .With<ItemUI>()
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