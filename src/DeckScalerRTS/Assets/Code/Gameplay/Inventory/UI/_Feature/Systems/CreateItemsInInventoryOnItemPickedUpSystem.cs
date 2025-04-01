using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CreateItemsInInventoryOnItemPickedUpSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<TakeItemEvent>()
                .Build();

        private static PrimaryEntityIndex<UiScope, InventorySlotModel, EntityID> InventorySlotIndex
            => Contexts.Instance.Get<UiScope>().GetPrimaryIndex<InventorySlotModel, EntityID>();

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