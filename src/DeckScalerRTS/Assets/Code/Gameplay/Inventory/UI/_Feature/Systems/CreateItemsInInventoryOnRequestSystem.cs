using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CreateItemsInInventoryOnRequestSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<RequestUpdateInventoryUI>()
                .And<SelectedUnit>()
                .Build();

        private static EntityIndex<UiScope, UiOfInventorySlot, EntityID> InventorySlotIndex
            => Contexts.Instance.Get<UiScope>().GetIndex<UiOfInventorySlot, EntityID>();

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

                    var slots = InventorySlotIndex.GetEntities(slot.ID());
                    foreach (var slotView in slots)
                    {
                        if (!slotView.Has<ItemInSlot>() && !slotView.Is<Destroy>())
                            UIFactory.CreateItemInSlot(itemID.GetEntity(), slotView);
                    }
                }
            }
        }
    }
}