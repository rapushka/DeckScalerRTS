namespace DeckScaler
{
    public interface IGameStateMachine : IService
    {
        void ToState<TState>() where TState : IState, new();
    }

    public class GameStateMachine : IGameStateMachine
    {
        private readonly TypeDictionary<IState> _statesMap = new();

        private IState _currentState;

        public void ToState<TState>()
            where TState : IState, new()
        {
            (_currentState as IExitState)?.OnExit();

            _currentState = Get<TState>();
            _currentState.OnEnter(this);
        }

        private TState Get<TState>()
            where TState : IState, new()
            => _statesMap.GetOrAdd(() => new TState());
    }
}