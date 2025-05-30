using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class MoveToPositionSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<MoveToPosition>()
                .And<WorldPosition>()
                .And<MovementSpeed>()
                .Without<PathSeeker>()
                .Build();

        private static ITimeService Time => ServiceLocator.Resolve<ITimeService>();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var target = entity.Get<MoveToPosition>().Value;
                var position = entity.Get<WorldPosition>().Value;
                var speed = entity.Get<MovementSpeed>().Value;

                var scaledSpeed = speed * Time.GameplayDelta;
                var direction = (target - position).normalized;

                var distance = position.DistanceTo(target);

                if (distance <= scaledSpeed)
                {
                    entity
                        .Set<WorldPosition, Vector2>(target)
                        .Remove<MoveToPosition>();
                    continue;
                }

                var movement = direction * scaledSpeed;
                entity.Set<WorldPosition, Vector2>(position + movement);
            }
        }
    }
}