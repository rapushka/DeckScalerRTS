using Entitas.Generic;

namespace DeckScaler
{
    // Unit -> Item "Go to the item and then take it"
    public sealed class PickUpItemOrder : ValueComponent<EntityID>, IInScope<GameScope> { }

    // Unit -> Item "Take the Item to your Inventory rn"
    public sealed class TakeItemEvent : ValueComponent<EntityID>, IInScope<GameScope> { }

    // Fort this unit (to Which this component is attached to)
    public sealed class RequestUpdateInventoryUI : FlagComponent, IInScope<GameScope> { }
}