using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroyOldInventoryItemsUIOnUpdateRequestedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<RequestUpdateInventoryUI>()
                .And<SelectedUnit>()
                .Build();

        private static EntityIndex<UiScope, UiOfInventorySlot, EntityID> InventorySlotIndex
            => Contexts.Instance.Get<UiScope>().GetIndex<UiOfInventorySlot, EntityID>();

        private static EntityIndex<UiScope, UiOfItem, EntityID> InventoryItemIndex
            => Contexts.Instance.Get<UiScope>().GetIndex<UiOfItem, EntityID>();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var inventory = InventoryUtils.GetInventory(unit.ID());
                foreach (var slot in inventory)
                {
                    if (!slot.TryGet<ItemInSlot, EntityID>(out var itemID))
                        continue;

                    var slotUIs = InventorySlotIndex.GetEntities(slot.ID());
                    foreach (var slotUI in slotUIs)
                        slotUI.RemoveSafely<ItemInSlot>();

                    var itemUIs = InventoryItemIndex.GetEntities(itemID);
                    foreach (var itemUI in itemUIs)
                        itemUI.Is<Destroy>(true);
                }
            }
        }
    }
}