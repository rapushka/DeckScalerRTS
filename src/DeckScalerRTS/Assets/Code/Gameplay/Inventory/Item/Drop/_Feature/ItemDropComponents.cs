using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    /// Event -> Item Model
    public sealed class DropItemToWorldOrder : ValueComponent<EntityID>, IInScope<GameScope> { }

    public sealed class DroppingDrink : FlagComponent, IInScope<GameScope> { }

    // "Go there and drop item in that place"
    public sealed class DropItemOnPositionOrder : ValueComponent<Vector2>, IInScope<GameScope> { }

    /// Event -> Item
    public sealed class ItemDroppedEvent : ValueComponent<EntityID>, IInScope<GameScope> { }

    public sealed class ProcessingItemDrop : FlagComponent, IInScope<GameScope> { }
}