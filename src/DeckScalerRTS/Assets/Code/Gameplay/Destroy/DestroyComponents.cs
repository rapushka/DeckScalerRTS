using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Destroy : FlagComponent, IInScope<GameScope>, IInScope<UiScope> { }

    public sealed class DestroyAfterDelay : ValueComponent<Timer>, IInScope<GameScope> { }
}