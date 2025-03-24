using System.Linq;
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

        private static EntityIndex<GameScope, InventorySlot, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InventorySlot, EntityID>();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var itemID = unit.Get<TakeItemEvent, EntityID>();

                var inventory = Index.GetEntities(unit.ID());
                var itemSlot = inventory.FirstOrDefault(s => !s.Has<ItemInSlot>());

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