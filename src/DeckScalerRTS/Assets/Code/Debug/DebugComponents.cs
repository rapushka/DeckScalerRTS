using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DebugName : ValueComponent<string>, IInScope<GameScope>, IInScope<UiScope> { }
}