using Entitas.Generic;

namespace DeckScaler
{
    public sealed class PlayerWallet : FlagComponent, IInScope<GameScope> { }

    public sealed class Money : ValueComponent<int>, IInScope<GameScope> { }
}