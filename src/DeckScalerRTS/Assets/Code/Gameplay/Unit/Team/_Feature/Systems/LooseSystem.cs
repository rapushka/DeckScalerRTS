using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class LooseSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _looseTimers
            = GroupBuilder<GameScope>
                .With<LooseAfterTimer>()
                .Build();

        private static IGameStateMachine StateMachine => ServiceLocator.Resolve<IGameStateMachine>();

        private static ITimeService Time => ServiceLocator.Resolve<ITimeService>();

        public void Execute()
        {
            foreach (var entity in _looseTimers)
            {
                var timer = entity.Get<LooseAfterTimer, Timer>();
                timer.Tick(Time.Delta);

                if (!timer.IsElapsed)
                    continue;

                StateMachine.ToState<LooseGameState>();
                entity.Add<Destroy>();
                break;
            }
        }
    }
}