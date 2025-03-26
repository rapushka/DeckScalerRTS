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
                var itemSlot = InventoryUtils.GetFirstFreeSlotOrDefault(unitID);

                if (itemSlot is null)
                {
                    Debug.LogError("TODO: how to deal when trying to take an Item with no free Inventory Slots??");
                    continue;
                }

                itemSlot
                    .Add<ItemInSlot, EntityID>(itemID)
                    ;

                var item = itemID.GetEntity();
                item
                    .Is<LyingOnGround>(false)
                    .Set<Visible, bool>(false)
                    .Set<ChildOf, EntityID>(itemSlot.ID())
                    ;
            }
        }
    }
}