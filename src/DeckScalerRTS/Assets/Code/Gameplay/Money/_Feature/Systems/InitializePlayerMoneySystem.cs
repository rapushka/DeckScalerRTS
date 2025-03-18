using Entitas;

namespace DeckScaler
{
    public sealed class InitializePlayerMoneySystem : IInitializeSystem
    {
        private static EconomyConfig EconomyConfig => ServiceLocator.Resolve<IGameConfig>().Economy;

        public void Initialize()
        {
            CreateEntity.Empty()
                .Add<DebugName, string>("player's wallet")
                .Add<PlayerWallet>()
                .Add<Money, int>(EconomyConfig.MoneyAtStart)
                ;
        }
    }
}