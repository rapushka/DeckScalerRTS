using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IShopFactory : IService
    {
        Entity<GameScope> Create(Vector2 position);
        Entity<GameScope> CreateShopStock(Vector2 position, EntityID shopID);

        Entity<GameScope> CreateRandomItem();
    }

    public class ShopFactory : IShopFactory
    {
        private static IEntityBehaviourFactory ViewFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        private static IUnitFactory UnitFactory => ServiceLocator.Resolve<IUnitFactory>();

        private static EconomyConfig.ShopConfig ShopConfig => ServiceLocator.Resolve<IGameConfig>().Economy.Shop;

        public Entity<GameScope> Create(Vector2 position)
        {
            var view = ViewFactory.CreateShopView(position);
            var shop = view.Entity
                    .Add<DebugName, string>("Shop")
                    .Add<Shop>()
                    .Add<WorldPosition, Vector2>(position)
                    .Add<Restock>()
                ;

            var shopID = shop.ID();

            var stocksRoot = shop.Get<ShopSlotsRoot, Transform>().position;
            for (var i = 0; i < ShopConfig.UnitSlots; i++)
            {
                var stockPosition = stocksRoot.Add(x: i * 1.5f);
                CreateShopStock(stockPosition, shopID);
            }

            return shop;
        }

        public Entity<GameScope> CreateRandomItem()
        {
            var unitID = ShopConfig.IssueRandomUnit();
            return CreateUnitInShop(unitID);
        }

        public Entity<GameScope> CreateShopStock(Vector2 position, EntityID shopID)
            => ViewFactory.CreateShopStockView(position).Entity
                .Add<DebugName, string>("shop stock")
                .Add<BuyStockButton>()
                .Add<Clickable>()
                .Add<Visible, bool>(true)
                .Add<StockInShop, EntityID>(shopID)
                .Add<ChildOf, EntityID>(shopID);

        private Entity<GameScope> CreateUnitInShop(UnitIDRef unitID)
            => UnitFactory.CreateInShop(unitID, new());
    }
}