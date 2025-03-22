using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class GainMoneySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<GainMoneyEvent>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _wallets
            = GroupBuilder<GameScope>
                .With<PlayerWallet>()
                .Build();

        public void Execute()
        {
            foreach (var e in _events)
            foreach (var aWallet in _wallets)
            {
                var increase = e.Get<GainMoneyEvent, int>();
                aWallet.Increment<Money>(increase);
            }
        }
    }
}