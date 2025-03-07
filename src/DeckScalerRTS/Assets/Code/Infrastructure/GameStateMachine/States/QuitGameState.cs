namespace DeckScaler
{
    public class QuitGameState : IState
    {
        public void OnEnter(GameStateMachine stateMachine)
        {
            Game.Instance.Quit();
        }
    }
}