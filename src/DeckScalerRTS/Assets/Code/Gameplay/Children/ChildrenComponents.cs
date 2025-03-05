using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ChildOf : IndexComponent<EntityID>, IInScope<GameScope> { }
}