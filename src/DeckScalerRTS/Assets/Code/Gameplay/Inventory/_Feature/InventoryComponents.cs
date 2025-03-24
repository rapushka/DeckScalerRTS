using Entitas.Generic;

namespace DeckScaler
{
    ///  InventorySlot -> Unit
    public sealed class InventorySlot : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class HasInventory : FlagComponent, IInScope<GameScope> { }

    public sealed class HasAnyFreeInventorySlot : FlagComponent, IInScope<GameScope> { }

    /// InventorySlot -> Item
    public sealed class ItemInSlot : ValueComponent<EntityID>, IInScope<GameScope> { }
}