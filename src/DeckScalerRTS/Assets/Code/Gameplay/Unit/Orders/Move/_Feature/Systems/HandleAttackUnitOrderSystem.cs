using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class HandleAttackUnitOrderSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<OrderOnPositionEvent>()
                .And<OrderListener>()
                .Without<Processed>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _enemies
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<OnEnemySide>()
                .And<WorldPosition>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var e in _events.GetEntities(_buffer))
            foreach (var enemy in _enemies)
            {
                var targetPosition = e.Get<OrderOnPositionEvent, Vector2>();
                var enemyCollider = enemy.Get<Collider>().Value;
                var isClickOnEnemy = enemyCollider.OverlapPoint(targetPosition);

                if (!isClickOnEnemy)
                    continue;

                var listener = e.Get<OrderListener, EntityID>().GetEntity();
                listener
                    .Set<Opponent, EntityID>(enemy.ID())
                    .Is<InAutoAttackState>(false)
                    ;

                e.Is<Processed>(true)
                    .Is<ProcessedAsAttackOrder>(true);

                break;
            }
        }
    }
}