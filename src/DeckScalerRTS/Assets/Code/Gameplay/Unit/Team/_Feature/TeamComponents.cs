using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnSide : ValueComponent<Side>, IInScope<GameScope> { }

    public sealed class OnPlayerSide : FlagComponent, IInScope<GameScope> { }

    public sealed class OnEnemySide : FlagComponent, IInScope<GameScope>, IEvent<Self> { }

    public sealed class Fella : FlagComponent, IInScope<GameScope> { }
}