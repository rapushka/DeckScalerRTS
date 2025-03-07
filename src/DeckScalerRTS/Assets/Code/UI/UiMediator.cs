namespace DeckScaler
{
    public interface IUiMediator : IService
    {
        void OpenPage<TPage>() where TPage : BasePage;

        void ToGameState<TState>() where TState : IState, new();
    }

    public class UiMediator : IUiMediator
    {
        private static IPagesService     PagesService => ServiceLocator.Resolve<IPagesService>();
        private static IGameStateMachine StateMachine => ServiceLocator.Resolve<IGameStateMachine>();

        public void OpenPage<TPage>() where TPage : BasePage
            => PagesService.OpenPage<TPage>();

        public void ToGameState<TState>() where TState : IState, new()
            => StateMachine.ToState<TState>();
    }
}