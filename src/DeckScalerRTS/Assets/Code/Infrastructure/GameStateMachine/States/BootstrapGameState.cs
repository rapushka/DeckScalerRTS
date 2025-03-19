using Entitas.Generic;

namespace DeckScaler
{
    public class BootstrapGameState : IState
    {
        public void OnEnter(GameStateMachine stateMachine)
        {
            // Scopes
            Contexts.Instance.InitializeScope<GameScope>();
            Contexts.Instance.InitializeScope<InputScope>();
            Contexts.Instance.InitializeScope<UiScope>();

            // Indexes
            Contexts.Instance.Get<GameScope>().GetPrimaryIndex<ID, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<AbilityOf, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<ChildOf, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<OnTent, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<ItemInShop, EntityID>().Initialize();

#if UNITY_EDITOR
            Entity<GameScope>.Formatter = new GameEntityFormatter();
            Entity<UiScope>.Formatter = new UiEntityFormatter();
#endif

            ServiceLocator.Resolve<IPagesService>().Initialize();

            stateMachine.ToState<MainMenuGameState>();
        }
    }
}