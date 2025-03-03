using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CurrentPath : ValueComponent<Pathfinding.Path>, IInScope<GameScope> { }
}