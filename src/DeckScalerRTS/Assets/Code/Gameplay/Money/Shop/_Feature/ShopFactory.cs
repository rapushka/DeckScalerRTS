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
                var unitPosition = unitSlotsRoot.Add(x: i * 1.5f);

                Debug.Log(
                    $"view = {view.transform.position}"
                    + $"| unitPosition = {unitPosition}"
                    + $"| unitSlotsRoot = {unitSlotsRoot}"
                );

                CreateUnitInShop(unitID, unitPosition, shopID);
            }

            return shop;
        }

        public Entity<GameScope> CreateUnitInShop(UnitIDRef unitID, Vector2 position, EntityID shopID)
            => UnitFactory.CreateInShop(unitID, position)
                .Add<ItemInShop, EntityID>(shopID)
                .Add<ChildOf, EntityID>(shopID);
    }
}