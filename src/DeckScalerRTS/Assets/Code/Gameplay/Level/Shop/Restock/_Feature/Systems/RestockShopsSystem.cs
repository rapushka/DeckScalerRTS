using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class RestockShopsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _shops
            = GroupBuilder<GameScope>
                .With<Shop>()
                .And<Restock>()
                .Build();

        private static IShopFactory ShopFactory => ServiceLocator.Resolve<IShopFactory>();

        private static EntityIndex<GameScope, StockInShop, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<StockInShop, EntityID>();

        public void Execute()
        {
            foreach (var shop in _shops)
            {
                var shopID = shop.ID();

                var stocks = Index.GetEntities(shopID);

                foreach (var stock in stocks)
                {
                    var itemInStockPosition = stock.Get<ShopStockItemRoot>().Value.position;

                    stock.GetOrDefault<IssuedItem>()?.Value
                        .GetEntity().Add<Destroy>();

                    var item = ShopFactory.CreateRandomItem()
                        .Set<WorldPosition, Vector2>(itemInStockPosition)
                        .Set<ChildOf, EntityID>(stock.ID());

                    var price = item.Get<Price, int>();

                    stock
                        .Set<IssuedItem, EntityID>(item.ID())
                        .Set<Price, int>(price)
                        ;
                }
            }
        }
    }
}