using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Tent : FlagComponent, IInScope<GameScope> { }

    public sealed class OnBase : IndexComponent<EntityID>, IInScope<GameScope> { }
}