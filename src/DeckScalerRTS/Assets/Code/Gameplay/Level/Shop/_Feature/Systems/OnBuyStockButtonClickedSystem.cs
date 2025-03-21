using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnBuyStockButtonClickedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _buyStockButtons
            = GroupBuilder<GameScope>
                .With<BuyStockButton>()
                .And<Clicked>()
                .And<IssuedItem>()
                .And<Available>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new();

        public void Execute()
        {
            foreach (var stock in _buyStockButtons.GetEntities(_buffer))
            {
                var item = stock.Pop<IssuedItem, EntityID>().GetEntity();

                item
                    .Add<JustPurchased>()
                    .Remove<ChildOf>()
                    ;

                stock.Set<Visible, bool>(false);
            }
        }
    }
}