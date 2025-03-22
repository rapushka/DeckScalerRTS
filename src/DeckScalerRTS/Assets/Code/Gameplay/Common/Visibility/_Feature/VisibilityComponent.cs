using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Visible : ValueComponent<bool>, IInScope<GameScope>, IEvent<Self> { }

    public sealed class Available : FlagComponent, IInScope<GameScope>, IEvent<Self> { }
}