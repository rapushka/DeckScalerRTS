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
                .Without<Disabled>()
                .Build();

        public void Execute()
        {
            foreach (var stock in _buyStockButtons)
            {
                var price = stock.Get<Price>().Value;
                stock.Get<IssuedItem>().Value.GetEntity()
                    .Add<JustPurchased>();

                stock.Set<Visible, bool>(false);

                CreateEntity.OneFrame()
                    .Add<SpendMoneyEvent, int>(price);
            }
        }
    }
}