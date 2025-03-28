using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Draggable : FlagComponent, IInScope<UiScope> { }

    public sealed class Dragging : FlagComponent, IInScope<UiScope>, IEvent<Self> { }

    public sealed class Dropped : FlagComponent, IInScope<UiScope> { }
}