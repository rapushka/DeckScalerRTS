using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SelectionRect : ValueComponent<SelectionAreaView>, IInScope<GameScope> { }

    public sealed class Selecting : FlagComponent, IInScope<GameScope> { }
}