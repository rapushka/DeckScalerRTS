using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UpdateInventoryItemSpriteUiViewSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _slotViews
            = GroupBuilder<UiScope>
                .With<InventoryItemSlotUiView>()
                .And<ItemSprite>()
                .Build();

        public void Execute()
        {
            foreach (var slotView in _slotViews)
            {
                var slot = slotView.Get<InventoryItemSlotUiView>().Value.GetEntity();
                var sprite = slot.GetItemSpriteOrDefault();

                slotView.Set<ItemSprite, Sprite>(sprite);
            }
        }
    }
}