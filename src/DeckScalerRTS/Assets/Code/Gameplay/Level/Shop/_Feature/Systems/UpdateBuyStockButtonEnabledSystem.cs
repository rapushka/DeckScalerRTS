using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateBuyStockButtonEnabledSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _buyStockButtons
            = GroupBuilder<GameScope>
                .With<BuyStockButton>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _playerWallets
            = GroupBuilder<GameScope>
                .With<PlayerWallet>()
                .And<Money>()
                .Build();

        public void Execute()
        {
            foreach (var stock in _buyStockButtons)
            foreach (var wallet in _playerWallets)
            {
                var money = wallet.Get<Money>().Value;
                var price = stock.Get<Price>().Value;

                stock.Is<Disabled>(money < price);
            }
        }
    }
}