using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class PlaceItemInHighlightedSlotOnDropSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggedItems
            = GroupBuilder<UiScope>
                .With<ItemUI>()
                .And<Dropped>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _highlightedSlots
            = GroupBuilder<UiScope>
                .With<UiOfInventorySlot>()
                .And<Highlight>()
                .Build();

        public void Execute()
        {
            foreach (var item in _draggedItems)
            foreach (var slot in _highlightedSlots)
            {
                var rectTransform = (RectTransform)slot.Get<UiView>().Value.transform;

                item
                    .Set<UiParent, RectTransform>(rectTransform)
                    .Set<InitUiParent, RectTransform>(rectTransform)
                    ;
            }
        }
    }
}