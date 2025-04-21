using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class SqueezeOutSystem : IExecuteSystem
    {
        private const float UnitRadius = 0.5f;

        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Collider>()
                .And<WorldPosition>()
                // .Without<MoveToPosition>()
                .Build();

        private static ITimeService TimeService => ServiceLocator.Resolve<ITimeService>();

        public void Execute()
        {
            foreach (var unitA in _units)
            foreach (var unitB in _units)
            {
                if (unitA == unitB)
                    continue;

                var positionA = unitA.Get<WorldPosition>().Value;
                var positionB = unitB.Get<WorldPosition>().Value;

                var distance = positionA.DistanceTo(positionB);

                if (distance > UnitRadius)
                    continue;

                // var colliderA = (CircleCollider2D)unitA.Get<Collider>().Value;
                // var colliderB = (CircleCollider2D)unitB.Get<Collider>().Value;

                var direction = (positionB - positionA).normalized;
                var overlap = 2 * UnitRadius - distance;

                if (overlap > 0)
                {
                    var speedA = unitA.Get<MovementSpeed>().Value;
                    var speedB = unitB.Get<MovementSpeed>().Value;
                    var totalSpeed = speedA + speedB;

                    var pushA = speedA / totalSpeed * overlap * TimeService.GameplayDelta;
                    var pushB = speedB / totalSpeed * overlap * TimeService.GameplayDelta;

                    unitA.Set<WorldPosition, Vector2>(positionA - direction * pushA);
                    unitB.Set<WorldPosition, Vector2>(positionB + direction * pushB);
                }
            }
        }
    }
}