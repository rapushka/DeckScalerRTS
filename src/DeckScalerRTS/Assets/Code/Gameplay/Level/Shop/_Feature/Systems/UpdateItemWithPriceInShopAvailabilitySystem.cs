using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateItemWithPriceInShopAvailabilitySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _entitiesWithPrice
            = GroupBuilder<GameScope>
                .With<Price>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _playerWallets
            = GroupBuilder<GameScope>
                .With<PlayerWallet>()
                .And<Money>()
                .Build();

        public void Execute()
        {
            foreach (var item in _entitiesWithPrice)
            foreach (var wallet in _playerWallets)
            {
                var money = wallet.Get<Money>().Value;
                var price = item.Get<Price>().Value;

                item.Is<Available>(money >= price);
            }
        }
    }
}