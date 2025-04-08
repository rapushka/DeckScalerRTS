using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class OrderUseItemOnUnitIfDropOnUnitSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _unitsDroppingItems
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<DropItemToWorldOrder>()
                .And<DroppingDrink>()
                .And<ProcessingItemDrop>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _hoveredUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Hovered>()
                .And<OnPlayerSide>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(4);

        public void Execute()
        {
            foreach (var unit in _unitsDroppingItems.GetEntities(_buffer))
            foreach (var hovered in _hoveredUnits)
            {
                var targetPosition = hovered.Get<WorldPosition>().Value;

                unit
                    .Add<UseDrinkOn, EntityID>(hovered.ID())
                    .Add<MoveToPosition, Vector2>(targetPosition)
                    .Remove<ProcessingItemDrop>()
                    ;

                break;
            }
        }
    }
}