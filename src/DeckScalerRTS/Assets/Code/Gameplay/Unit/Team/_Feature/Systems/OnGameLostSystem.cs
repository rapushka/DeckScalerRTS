using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnGameLostSystem : ICleanupSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<GameLostEvent>()
                .Build();

        private static IGameStateMachine StateMachine => ServiceLocator.Resolve<IGameStateMachine>();

        public void Cleanup()
        {
            foreach (var _ in _events)
                StateMachine.ToState<LooseGameState>();
        }
    }
}