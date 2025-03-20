using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class SpendMoneySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SpendMoneyEvent>()
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
                var decrease = e.Get<SpendMoneyEvent, int>();
                aWallet.Increment<Money>(-decrease);
            }
        }
    }
}