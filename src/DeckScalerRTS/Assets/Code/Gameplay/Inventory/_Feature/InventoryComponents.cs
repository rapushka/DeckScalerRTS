using Entitas.Generic;

namespace DeckScaler
{
    ///  InventorySlot -> Unit
    public sealed class InventorySlot : ValueComponent<EntityID>, IInScope<GameScope> { }

    public sealed class HasInventory : FlagComponent, IInScope<GameScope> { }

    public sealed class HasAnyFreeInventorySlot : FlagComponent, IInScope<GameScope> { }
}