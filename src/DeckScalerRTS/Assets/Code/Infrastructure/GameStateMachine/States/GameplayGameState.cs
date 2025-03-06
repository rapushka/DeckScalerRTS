using UnityEngine;

namespace DeckScaler
{
    public class GameplayGameState : IState, IExitState
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private GameplayFeatureRunner _ecsRunner;

        public void OnEnter(GameStateMachine stateMachine)
        {
            UiMediator.OpenPage<GameplayPage>();

            _ecsRunner = new GameObject(nameof(GameplayFeatureRunner))
                .AddComponent<GameplayFeatureRunner>();
        }

        public void OnExit()
        {
            _ecsRunner.DestroyObject();
        }
    }
}