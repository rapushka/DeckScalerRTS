using UnityEngine;

namespace DeckScaler
{
    public class GameplayGameState : IState, IExitState
    {
        private GameplayFeatureRunner _ecsRunner;

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static Camera             MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;
        private static IIdentifiesService IdService  => ServiceLocator.Resolve<IIdentifiesService>();

        public void OnEnter(GameStateMachine stateMachine)
        {
            UiMediator.OpenPage<GameplayPage>();

            _ecsRunner = new GameObject(nameof(GameplayFeatureRunner))
                .AddComponent<GameplayFeatureRunner>();
        }

        public void OnExit()
        {
            _ecsRunner.DestroyObject();
            MainCamera.transform.SetPosition(x: 0f, y: 0f);
            IdService.Reset();
        }
    }
}