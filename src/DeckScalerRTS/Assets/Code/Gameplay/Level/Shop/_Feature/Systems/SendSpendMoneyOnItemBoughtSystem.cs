using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SendSpendMoneyOnItemBoughtSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _buyStockButtons
            = GroupBuilder<GameScope>
                .With<ItemForSale>()
                .And<Price>()
                .And<Clicked>()
                .And<Available>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new();

        public void Execute()
        {
            foreach (var stock in _buyStockButtons.GetEntities(_buffer))
            {
                var price = stock.Get<Price>().Value;
                MoneyUtils.SpendMoney(price);
            }
        }
    }
}