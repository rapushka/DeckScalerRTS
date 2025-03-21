using Entitas.Generic;

namespace DeckScaler
{
    public sealed class PlayerWallet : FlagComponent, IInScope<GameScope> { }

    public sealed class Money : ValueComponent<int>, IInScope<GameScope> { }

    public sealed class GainMoneyEvent : ValueComponent<int>, IInScope<GameScope> { }

    public sealed class SpendMoneyEvent : ValueComponent<int>, IInScope<GameScope> { }
}