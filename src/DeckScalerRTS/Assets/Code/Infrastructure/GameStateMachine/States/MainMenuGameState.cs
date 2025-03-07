namespace DeckScaler
{
    public class MainMenuGameState : IState
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public void OnEnter(GameStateMachine stateMachine)
        {
            UiMediator.OpenPage<MainMenuPage>();
        }
    }
}