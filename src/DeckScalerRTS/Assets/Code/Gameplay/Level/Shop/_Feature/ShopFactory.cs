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
        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        private static IUnitFactory UnitFactory => ServiceLocator.Resolve<IUnitFactory>();

        private static EconomyConfig.ShopConfig ShopConfig => ServiceLocator.Resolve<IGameConfig>().Economy.Shop;

        public Entity<GameScope> Create(Vector2 position)
        {
            var view = ViewFactory.CreateInWorld(ShopConfig.ViewPrefab, position);
            var shop = view.Entity
                    .Add<DebugName, string>("Shop")
                    .Add<Shop>()
                    .Add<WorldPosition, Vector2>(position)
                    .Add<Restock>()
                ;

            var shopID = shop.ID();

            var stocksRoot = shop.Get<ShopSlotsRoot, Transform>().position;
            SetupStocks(stocksRoot, shopID);
            SetupRestockButton(position, shopID);

            return shop;
        }

        public Entity<GameScope> CreateRandomItem()
        {
            var unitID = ShopConfig.IssueRandomUnit();
            return CreateUnitInShop(unitID);
        }

        public Entity<GameScope> CreateShopStock(Vector2 position, EntityID shopID)
            => ViewFactory.CreateInWorld(ShopConfig.StockViewPrefab, position).Entity
                .Add<DebugName, string>("shop stock")
                .Add<BuyStockButton>()
                .Add<Clickable>()
                .Add<ItemForSale>()
                .Add<Visible, bool>(true)
                .Add<StockInShop, EntityID>(shopID)
                .Add<ChildOf, EntityID>(shopID);

        private Entity<GameScope> CreateUnitInShop(UnitIDRef unitID)
            => UnitFactory.CreateInShop(unitID, new());

        private void SetupStocks(Vector2 rootPosition, EntityID shopID)
        {
            for (var i = 0; i < ShopConfig.UnitSlots; i++)
            {
                var stockPosition = rootPosition.Add(x: i * 1.5f);
                CreateShopStock(stockPosition, shopID);
            }
        }

        private static void SetupRestockButton(Vector2 shopPosition, EntityID shopID)
        {
            var restockButtonPosition = shopPosition.Add(x: -1.8f, y: 2.17f);
            ViewFactory.CreateInWorld(ShopConfig.RestockButtonPrefab, restockButtonPosition).Entity
                .Add<DebugName, string>("Restock Shop Button")
                .Add<RestockButton, EntityID>(shopID)
                .Add<ChildOf, EntityID>(shopID)
                .Add<Price, int>(ShopConfig.RestockPrice)
                .Add<Available>()
                .Add<ItemForSale>()
                ;
        }
    }
}