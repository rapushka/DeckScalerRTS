using Entitas.Generic;

namespace DeckScaler
{
    public sealed class PickUpItemOrder : ValueComponent<EntityID>, IInScope<GameScope> { }
}