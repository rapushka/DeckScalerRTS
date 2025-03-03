using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class TriggerAutoAttackSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _attackingUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<InAutoAttackState>()
                .And<AttackTriggerRadius>()
                .And<WorldPosition>()
                .And<OnSide>()
                .Without<Opponent>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _targetUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<WorldPosition>()
                .And<OnSide>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var attackerUnit in _attackingUnits.GetEntities(_buffer))
            {
                var maxDistance = attackerUnit.Get<AttackTriggerRadius, float>();
                var oppositeSide = attackerUnit.Get<OnSide, Side>().Flip();
                var attackerPosition = attackerUnit.Get<WorldPosition, Vector2>();

                var closestDistance = (float?)null;
                var closestTargetID = (EntityID?)null;

                foreach (var targetUnit in _targetUnits)
                {
                    var targetUnitSide = targetUnit.Get<OnSide, Side>();
                    if (targetUnitSide != oppositeSide)
                        continue;

                    var targetPosition = targetUnit.Get<WorldPosition, Vector2>();
                    var distance = attackerPosition.DistanceTo(targetPosition);

                    if (distance > maxDistance)
                        continue;

                    if (!closestDistance.HasValue || closestDistance.Value > distance)
                    {
                        closestDistance = distance;
                        closestTargetID = targetUnit.ID();
                    }
                }

                if (closestTargetID.HasValue)
                    attackerUnit.Set<Opponent, EntityID>(closestTargetID.Value);
            }
        }
    }
}