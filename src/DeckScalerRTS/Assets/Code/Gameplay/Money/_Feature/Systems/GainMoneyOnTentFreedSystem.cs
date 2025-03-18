using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class GainMoneyOnTentFreedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _justFreedTents
            = GroupBuilder<GameScope>
                .With<TentJustFreed>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _wallets
            = GroupBuilder<GameScope>
                .With<PlayerWallet>()
                .And<Money>()
                .Build();

        private static EconomyConfig EconomyConfig => ServiceLocator.Resolve<IGameConfig>().Economy;

        public void Execute()
        {
            foreach (var _ in _justFreedTents)
            foreach (var wallet in _wallets)
            {
                wallet.Increment<Money>(EconomyConfig.MoneyGainForFreedTent);
            }
        }
    }
}