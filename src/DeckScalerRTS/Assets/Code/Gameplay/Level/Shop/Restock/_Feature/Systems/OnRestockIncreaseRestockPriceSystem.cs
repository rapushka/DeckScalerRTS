using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnRestockIncreaseRestockPriceSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _clickedRestockButtons
            = GroupBuilder<GameScope>
                .With<RestockButton>()
                .And<Clicked>()
                .And<Available>()
                .Build();

        private static EconomyConfig.ShopConfig Config => ServiceLocator.Resolve<IGameConfig>().Economy.Shop;

        public void Execute()
        {
            foreach (var button in _clickedRestockButtons)
                button.Increment<Price>(Config.PerRestockIncrement);
        }
    }
}