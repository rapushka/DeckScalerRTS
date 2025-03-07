namespace DeckScaler
{
    public class LooseGameState : IState
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public void OnEnter(GameStateMachine stateMachine)
        {
            UiMediator.OpenPage<LooseScreenPage>();
        }
    }
}