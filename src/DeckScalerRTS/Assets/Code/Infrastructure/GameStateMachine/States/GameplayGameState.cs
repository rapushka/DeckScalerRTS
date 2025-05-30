using UnityEngine;

namespace DeckScaler
{
    public class GameplayGameState : IState, IExitState
    {
        private GameplayFeatureRunner _ecsRunner;

        private static IUiMediator        UiMediator => ServiceLocator.Resolve<IUiMediator>();
        private static IIdentifiesService IdService  => ServiceLocator.Resolve<IIdentifiesService>();

        private static Camera MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;

        private static SelectedUnitsUiView SelectedUnitView => UiMediator.GetPage<GameplayHUDPage>().SelectedUnitView;

        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        public void OnEnter(GameStateMachine stateMachine)
        {
            ViewFactory.Init();
            UiMediator.OpenPage<GameplayHUDPage>();

            _ecsRunner = new GameObject(nameof(GameplayFeatureRunner))
                .AddComponent<GameplayFeatureRunner>();
        }

        public void OnExit()
        {
            _ecsRunner.DestroyObject();
            MainCamera.transform.SetPosition(x: 0f, y: 0f);
            MainCamera.orthographicSize = 5f;
            IdService.Reset();

            SelectedUnitView.Hide();
            ViewFactory.Dispose();
        }
    }
}