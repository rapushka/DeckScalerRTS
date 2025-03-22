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

        private static EconomyConfig EconomyConfig => ServiceLocator.Resolve<IGameConfig>().Economy;

        public void Execute()
        {
            foreach (var _ in _justFreedTents)
                MoneyUtils.GainMoney(EconomyConfig.MoneyGainForFreedTent);
        }
    }
}