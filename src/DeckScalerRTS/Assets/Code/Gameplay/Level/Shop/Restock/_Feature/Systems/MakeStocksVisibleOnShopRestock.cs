using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MakeStocksVisibleOnShopRestock : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _shops
            = GroupBuilder<GameScope>
                .With<Shop>()
                .And<Restock>()
                .Build();

        private static EntityIndex<GameScope, StockInShop, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<StockInShop, EntityID>();

        public void Execute()
        {
            foreach (var shop in _shops)
            foreach (var stock in Index.GetEntities(shop.ID()))
                stock.Set<Visible, bool>(true);
        }
    }
}