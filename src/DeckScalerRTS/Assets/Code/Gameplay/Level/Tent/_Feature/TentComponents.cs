using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Tent : FlagComponent, IInScope<GameScope> { }

    public sealed class OnTent : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class TentJustFreed : FlagComponent, IInScope<GameScope> { }
}