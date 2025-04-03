using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class DropItemWhenCloseToTargetSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<WorldPosition>()
                .And<MoveToPosition>()
                .And<DropItemOnPositionOrder>()
                .Build();

        private static UnitsConfig.CommonBalance UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units.Common;

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var unitPosition = unit.Get<WorldPosition, Vector2>();
                var targetPosition = unit.Get<DropItemOnPositionOrder, Vector2>();

                var distanceToItem = unitPosition.DistanceTo(targetPosition);

                if (distanceToItem > UnitsConfig.ItemsInteractRadius)
                    continue;

                DropItem(unit, targetPosition);
            }
        }

        private static void DropItem(Entity<GameScope> unit, Vector2 targetPosition)
        {
            var itemToDrop = unit.Get<DropItemToWorldOrder>().Value.GetEntity();

            unit
                .Remove<MoveToPosition>()
                .Remove<DropItemToWorldOrder>()
                .Remove<DropItemOnPositionOrder>()
                ;

            CreateEntity.OneFrame()
                .Add<ItemDroppedEvent>()
                ;

            var slot = itemToDrop.GetSlotOfItem().GetEntity();

            slot
                .Remove<ItemInSlot>()
                ;

            itemToDrop
                .Is<LyingOnGround>(true)
                .Set<Visible, bool>(true)
                .Set<WorldPosition, Vector2>(targetPosition)
                .Remove<ChildOf>() // TODO: child of wha?
                ;

            unit.AddSafely<RequestUpdateInventoryUI>();
        }
    }
}