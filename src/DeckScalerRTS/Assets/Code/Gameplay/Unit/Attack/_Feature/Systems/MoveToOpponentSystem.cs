using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class MoveToOpponentSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<InAutoAttackState>()
                .And<Opponent>()
                .And<WorldPosition>()
                .And<AttackTriggerRadius>()
                .Build();

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var maxDistance = unit.Get<AttackRange, float>();
                var attackerPosition = unit.Get<WorldPosition, Vector2>();

                var opponent = unit.Get<Opponent, EntityID>().GetEntity();
                var opponentPosition = opponent.Get<WorldPosition, Vector2>();
                var distance = opponentPosition.DistanceTo(attackerPosition);

                if (distance > maxDistance)
                    unit.AddSafely<MoveToPosition, Vector2>(opponentPosition);
                else
                    unit.RemoveSafely<MoveToPosition>();
            }
        }
    }
}