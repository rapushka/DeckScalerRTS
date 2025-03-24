using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class PickUpItemWhenUnitCloseEnoughSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<PickUpItemOrder>()
                .And<WorldPosition>()
                .Build();

        private static UnitsConfig.CommonBalance UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units.Common;

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var itemID = unit.Get<PickUpItemOrder, EntityID>();
                var item = itemID.GetEntity();

                var unitPosition = unit.Get<WorldPosition, Vector2>();
                var itemPosition = item.Get<WorldPosition, Vector2>();

                var distanceToItem = unitPosition.DistanceTo(itemPosition);

                if (distanceToItem > UnitsConfig.ItemsInteractRadius)
                    continue;

                unit
                    .Remove<MoveToPosition>()
                    .Remove<PickUpItemOrder>()
                    .Add<TakeItemEvent, EntityID>(itemID)
                    ;
            }
        }
    }
}