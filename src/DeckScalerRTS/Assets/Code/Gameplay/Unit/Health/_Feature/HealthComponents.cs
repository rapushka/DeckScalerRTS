using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MaxHealth : ValueComponent<float>, IInScope<GameScope>, IEvent<Self> { }

    public sealed class Health : ValueComponent<float>, IInScope<GameScope>, IEvent<Self> { }

    public sealed class Dead : FlagComponent, IInScope<GameScope> { }
}