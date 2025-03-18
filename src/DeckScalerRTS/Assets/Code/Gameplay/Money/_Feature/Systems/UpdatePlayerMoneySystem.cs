using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdatePlayerMoneySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _hudEntities
            = GroupBuilder<UiScope>
                .With<Hud>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _playerWallets
            = GroupBuilder<GameScope>
                .With<PlayerWallet>()
                .And<Money>()
                .Build();

        public void Execute()
        {
            foreach (var hud in _hudEntities)
            foreach (var wallet in _playerWallets)
            {
                var money = wallet.Get<Money>().Value;
                hud.Get<Hud>().Value.Money = money;
            }
        }
    }
}