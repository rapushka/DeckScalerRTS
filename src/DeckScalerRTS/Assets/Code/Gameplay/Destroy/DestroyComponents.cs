using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Destroy : FlagComponent, IInScope<GameScope> { }

    public sealed class DestroyAfterDelay : ValueComponent<Timer>, IInScope<GameScope> { }
}