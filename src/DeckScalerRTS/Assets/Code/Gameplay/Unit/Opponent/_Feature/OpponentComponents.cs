using Entitas.Generic;

namespace DeckScaler
{
    public sealed class Opponent : ValueComponent<EntityID>, IInScope<GameScope> { }
}