using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class OrderDropItemOnGroundSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<DropItemToWorldOrder>()
                .And<ProcessingItemDrop>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(4);

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var targetPosition = input.Get<MouseWorldPosition>().Value;

                unit
                    .Add<DropItemOnPositionOrder, Vector2>(targetPosition)
                    .Add<MoveToPosition, Vector2>(targetPosition)
                    .Remove<ProcessingItemDrop>()
                    ;
            }
        }
    }
}