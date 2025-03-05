using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CleanupDeadOpponentsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Opponent>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var hasValidOpponent = unit.TryGet<Opponent>(out var opponentID)
                    && opponentID.Value.TryGetEntity(out var opponent)
                    && !(opponent.Is<Dead>() || opponent.Is<Destroy>());

                if (!hasValidOpponent)
                    unit.Remove<Opponent>();
            }
        }
    }
}