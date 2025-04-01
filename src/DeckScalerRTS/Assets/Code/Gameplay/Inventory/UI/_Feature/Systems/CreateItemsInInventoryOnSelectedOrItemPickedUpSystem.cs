using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CreateItemsInInventoryOnSelectedOrItemPickedUpSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .Or<TakeItemEvent>()
                .Or<SelectedUnit>()
                .Build();

        private static PrimaryEntityIndex<UiScope, UiOfInventorySlot, EntityID> InventorySlotIndex
            => Contexts.Instance.Get<UiScope>().GetPrimaryIndex<UiOfInventorySlot, EntityID>();

        private static IInventoryUIFactory UIFactory => ServiceLocator.Resolve<IInventoryUIFactory>();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var inventory = InventoryUtils.GetInventory(unit.ID());
                foreach (var slot in inventory)
                {
                    if (!slot.TryGet<ItemInSlot, EntityID>(out var itemID))
                        continue;

                    var slotView = InventorySlotIndex.GetEntity(slot.ID());
                    if (slotView.Has<ItemInSlot>())
                        continue;

                    UIFactory.CreateItemInSlot(itemID.GetEntity(), slotView);
                }
            }
        }
    }
}