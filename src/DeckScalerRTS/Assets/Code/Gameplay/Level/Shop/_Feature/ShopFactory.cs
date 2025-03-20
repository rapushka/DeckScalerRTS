using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IShopFactory : IService
    {
        Entity<GameScope> Create(Vector2 position);
        Entity<GameScope> CreateUnitInShop(UnitIDRef unitID, Vector2 position, EntityID shopID);
    }

    public class ShopFactory : IShopFactory
    {
        private static IEntityBehaviourFactory ViewFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        private static EconomyConfig.ShopConfig ShopConfig => ServiceLocator.Resolve<IGameConfig>().Economy.Shop;

        private static IUnitFactory UnitFactory => ServiceLocator.Resolve<IUnitFactory>();

        public Entity<GameScope> Create(Vector2 position)
        {
            var view = ViewFactory.CreateShopView(position);
            var shop = view.Entity
                .Add<DebugName, string>("Shop")
                .Add<Shop>()
                .Add<WorldPosition, Vector2>(position);
            var shopID = shop.ID();

            var unitSlotsRoot = shop.Get<ShopSlotsRoot, Transform>().position;
            for (var i = 0; i < ShopConfig.UnitSlots; i++)
            {
                var unitID = ShopConfig.IssueRandomUnit();
                var stockPosition = unitSlotsRoot.Add(x: i * 1.5f);

                var item = CreateUnitInShop(unitID, stockPosition, shopID);
                var stock = CreateShopStock(stockPosition, shopID, item);
                var itemInStockPosition = stock.Get<ShopStockItemRoot>().Value.position;
                item.Set<WorldPosition, Vector2>(itemInStockPosition);
            }

            return shop;
        }

        public Entity<GameScope> CreateUnitInShop(UnitIDRef unitID, Vector2 position, EntityID shopID)
            => UnitFactory.CreateInShop(unitID, position)
                .Add<ChildOf, EntityID>(shopID);

        private Entity<GameScope> CreateShopStock(Vector2 position, EntityID shopID, Entity<GameScope> item)
        {
            var price = item.Get<Price>().Value;

            return ViewFactory.CreateShopStockView(position).Entity
                    .Add<DebugName, string>("shop stock")
                    .Add<BuyStockButton>()
                    .Add<Clickable>()
                    .Add<Price, int>(price)
                    .Add<Visible, bool>(true)
                    .Add<StockInShop, EntityID>(shopID)
                    .Add<ChildOf, EntityID>(shopID)
                    .Add<IssuedItem, EntityID>(item.ID())
                ;
        }
    }
}