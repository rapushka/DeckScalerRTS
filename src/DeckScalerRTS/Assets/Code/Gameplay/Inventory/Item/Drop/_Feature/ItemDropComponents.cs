using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DropDraggingItemToWorld : FlagComponent, IInScope<GameScope> { }

    public sealed class DropItemOnPosition : FlagComponent, IInScope<GameScope> { }
}