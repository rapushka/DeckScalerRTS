using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class MoveToNextWaypointSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<PathSeeker>()
                .And<Path>()
                .And<WorldPosition>()
                .And<MovementSpeed>()
                .Build();

        private static ITimeService Time => ServiceLocator.Resolve<ITimeService>();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var path = entity.Get<Path>().Value;

                if (!path.Any())
                {
                    RemoveComponents(entity);
                    continue;
                }

                if (!IsOutreachNextWaypoint(entity, out var nextPosition))
                {
                    entity.Set<WorldPosition, Vector2>(nextPosition);
                    continue;
                }

                path.Dequeue();

                if (!path.Any())
                {
                    entity.Set<WorldPosition, Vector2>(nextPosition);
                    RemoveComponents(entity);

                    continue;
                }

                IsOutreachNextWaypoint(entity, out nextPosition);
                entity.Set<WorldPosition, Vector2>(nextPosition);

                if (!path.Any())
                    RemoveComponents(entity);
            }
        }

        private void RemoveComponents(Entity<GameScope> entity)
            => entity.Remove<Path>()
                .RemoveSafely<GoingToPoint>()
                .Is<CalculatingPath>(false);

        private bool IsOutreachNextWaypoint(Entity<GameScope> entity, out Vector2 nextPosition)
        {
            var path = entity.Get<Path>().Value;
            var nextWaypoint = path.Peek();
            var position = entity.Get<WorldPosition>().Value;
            var speed = entity.Get<MovementSpeed>().Value;

            var scaledSpeed = speed * Time.GameplayDelta;
            var direction = (nextWaypoint - position).normalized;
            var movement = direction * scaledSpeed;

            var distanceToNextWaypoint = position.DistanceTo(nextWaypoint);
            var isOutreaches = distanceToNextWaypoint <= scaledSpeed;

            nextPosition = isOutreaches
                ? nextWaypoint
                : position + movement;

            return isOutreaches;
        }
    }
}