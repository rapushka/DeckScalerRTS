using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UnitTakesItemSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<TakeItemEvent>()
                .Build();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var itemID = unit.Get<TakeItemEvent, EntityID>();

                var unitID = unit.ID();
                var slot = InventoryUtils.GetFirstFreeSlotOrDefault(unitID);

                if (slot is null)
                {
                    Debug.LogError("TODO: how to deal when trying to take an Item with no free Inventory Slots??");
                    continue;
                }

                var item = itemID.GetEntity();
                InventoryUtils.TakeItemToSlot(item, slot);
            }
        }
    }
}