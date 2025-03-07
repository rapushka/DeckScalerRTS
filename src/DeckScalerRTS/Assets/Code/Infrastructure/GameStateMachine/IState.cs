namespace DeckScaler
{
    public interface IState
    {
        void OnEnter(GameStateMachine stateMachine);
    }

    public interface IExitState
    {
        void OnExit();
    }
}