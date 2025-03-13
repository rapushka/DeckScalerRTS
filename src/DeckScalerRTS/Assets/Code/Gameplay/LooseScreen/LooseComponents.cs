using Entitas.Generic;

namespace DeckScaler
{
    public sealed class LooseAfterTimer : ValueComponent<Timer>, IInScope<GameScope> { }

    public sealed class GameLostEvent : FlagComponent, IInScope<GameScope> { }
}