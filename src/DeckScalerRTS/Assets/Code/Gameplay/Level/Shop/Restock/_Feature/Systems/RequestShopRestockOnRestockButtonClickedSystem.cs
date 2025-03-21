using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class RequestShopRestockOnRestockButtonClickedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _clickedRestockButtons
            = GroupBuilder<GameScope>
                .With<RestockButton>()
                .And<Clicked>()
                .Build();

        public void Execute()
        {
            foreach (var button in _clickedRestockButtons)
            {
                var shop = button.Get<RestockButton>().Value.GetEntity();
                shop.Add<Restock>();
            }
        }
    }
}