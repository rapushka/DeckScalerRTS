using Entitas.Generic;

namespace DeckScaler
{
    public class BootstrapGameState : IState
    {
        private static IDebugService Debugger => ServiceLocator.Resolve<IDebugService>();

        private static IPagesService Pages => ServiceLocator.Resolve<IPagesService>();

        public void OnEnter(GameStateMachine stateMachine)
        {
            // Scopes
            Contexts.Instance.InitializeScope<GameScope>();
            Contexts.Instance.InitializeScope<InputScope>();
            Contexts.Instance.InitializeScope<UiScope>();

            // Indexes
            Contexts.Instance.Get<GameScope>().GetPrimaryIndex<ID, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<AbilityOwner, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<ChildOf, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<OnTent, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<StockInShop, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<InventorySlotOfUnit, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<InfluenceTarget, EntityID>().Initialize();

            Contexts.Instance.Get<UiScope>().GetIndex<UiOfInventorySlot, EntityID>().Initialize();
            Contexts.Instance.Get<UiScope>().GetIndex<UiOfItem, EntityID>().Initialize();

            CustomIndexes.Initialize();

            Debugger.Initialize();
            Pages.Initialize();

            stateMachine.ToState<MainMenuGameState>();
        }
    }
}