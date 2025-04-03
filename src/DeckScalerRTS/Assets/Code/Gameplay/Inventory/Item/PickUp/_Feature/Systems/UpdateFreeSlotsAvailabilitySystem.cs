using System.Linq;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateFreeSlotsAvailabilitySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<RequestUpdateInventoryUI>()
                .Build();

        private static EntityIndex<GameScope, InventorySlotOfUnit, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InventorySlotOfUnit, EntityID>();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var inventory = Index.GetEntities(unit.ID());

                unit
                    .Is<HasAnyFreeInventorySlot>(inventory.Any(s => !s.Has<ItemInSlot>()))
                    ;
            }
        }
    }
}