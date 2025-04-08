using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DiscardUseTrinketOnUnitSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _unitsDroppingItems
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<DropItemToWorldOrder>()
                .And<ProcessingItemDrop>()
                .Without<DroppingDrink>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _hoveredUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Hovered>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(4);

        public void Execute()
        {
            foreach (var unit in _unitsDroppingItems.GetEntities(_buffer))
            foreach (var _ in _hoveredUnits)
            {
                unit
                    .Remove<DropItemToWorldOrder>()
                    .Remove<ProcessingItemDrop>()
                    ;

                break;
            }
        }
    }
}