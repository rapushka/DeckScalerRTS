using Entitas.Generic;

namespace DeckScaler
{
    // "Go to the item and then take it"
    public sealed class PickUpItemOrder : ValueComponent<EntityID>, IInScope<GameScope> { }

    // "Take the Item to your Inventory rn"
    public sealed class TakeItemEvent : ValueComponent<EntityID>, IInScope<GameScope> { }
}