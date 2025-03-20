using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Visible : ValueComponent<bool>, IInScope<GameScope>, IEvent<Self> { }

    public sealed class Disabled : FlagComponent, IInScope<GameScope>, IEvent<Self> { }
}