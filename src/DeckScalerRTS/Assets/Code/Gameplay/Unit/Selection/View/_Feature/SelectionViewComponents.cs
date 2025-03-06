using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SelectionView : ValueComponent<SelectionAreaView>, IInScope<GameScope> { }

    public sealed class Selecting : FlagComponent, IInScope<GameScope> { }

    public sealed class SelectionDragEnded : FlagComponent, IInScope<GameScope> { }
}