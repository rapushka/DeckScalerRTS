using Entitas.Generic;

namespace DeckScaler
{
    ///  InventorySlot -> Unit
    public sealed class InventorySlotOfUnit : IndexComponent<EntityID>, IInScope<GameScope> { }

    public sealed class InventorySlotIndex : ValueComponent<int>, IInScope<GameScope> { }

    public sealed class HasInventory : FlagComponent, IInScope<GameScope> { }

    public sealed class HasAnyFreeInventorySlot : FlagComponent, IInScope<GameScope> { }

    /// InventorySlot or InventorySlotUI-> Item
    public sealed class ItemInSlot : ValueComponent<EntityID>, IInScope<GameScope>, IInScope<UiScope> { }
}