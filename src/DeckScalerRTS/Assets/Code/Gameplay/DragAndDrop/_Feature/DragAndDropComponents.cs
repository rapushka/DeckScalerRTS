using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Draggable : FlagComponent, IInScope<UiScope> { }

    public sealed class StartDragging : FlagComponent, IInScope<UiScope> { }

    public sealed class Dragging : FlagComponent, IInScope<UiScope> { }

    public sealed class Dropped : FlagComponent, IInScope<UiScope> { }
}