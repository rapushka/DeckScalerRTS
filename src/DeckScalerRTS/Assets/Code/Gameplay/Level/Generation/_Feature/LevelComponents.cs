using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Level : FlagComponent, IInScope<GameScope> { }

    public sealed class CurrentLevel : FlagComponent, IInScope<GameScope>, IUnique { }
}