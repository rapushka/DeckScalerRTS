using Entitas.Generic;

namespace DeckScaler
{
    public static class MoneyUtils
    {
        public static Entity<GameScope> GainMoney(int value)
            => CreateEntity.OneFrame()
                .Add<GainMoneyEvent, int>(value);

        public static Entity<GameScope> SpendMoney(int value)
            => CreateEntity.OneFrame()
                .Add<SpendMoneyEvent, int>(value);
    }
}