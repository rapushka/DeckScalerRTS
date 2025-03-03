using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class RemoveOpponentIfOutOfRangeSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _attackingUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<InAutoAttackState>()
                .And<AttackTriggerRadius>()
                .And<WorldPosition>()
                .And<Opponent>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var attackerUnit in _attackingUnits.GetEntities(_buffer))
            {
                var maxDistance = attackerUnit.Get<AttackTriggerRadius, float>();
                var attackerPosition = attackerUnit.Get<WorldPosition, Vector2>();

                var opponent = attackerUnit.Get<Opponent, EntityID>().GetEntity();
                var distance = opponent.Get<WorldPosition, Vector2>().DistanceTo(attackerPosition);

                if (distance > maxDistance)
                    attackerUnit.Remove<Opponent>();
            }
        }
    }
}