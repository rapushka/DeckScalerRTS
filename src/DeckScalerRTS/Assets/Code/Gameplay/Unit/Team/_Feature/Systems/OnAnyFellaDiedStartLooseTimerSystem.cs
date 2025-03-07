using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnAnyFellaDiedStartLooseTimerSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _deadFellas
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<Fella>()
                .And<Dead>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _looseTimers
            = GroupBuilder<GameScope>
                .With<LooseAfterTimer>()
                .Build();

        public void Execute()
        {
            if (_looseTimers.Any())
                return;

            foreach (var _ in _deadFellas)
            {
                CreateEntity.Empty()
                    .Add<DebugName, string>("loose timer")
                    .Add<LooseAfterTimer, Timer>(new(0.7f))
                    ;
                break;
            }
        }
    }
}