using Entitas.Generic;

namespace DeckScaler
{
    public interface IInventoryFactory : IService
    {
        Entity<GameScope> CreateSlot(EntityID unit, int slotIndex);
    }

    public class InventoryFactory : IInventoryFactory
    {
        public Entity<GameScope> CreateSlot(EntityID unit, int slotIndex)
            => CreateEntity.Empty()
                .Add<DebugName, string>("inventory slot")
                .Add<InventorySlotOfUnit, EntityID>(unit)
                .Add<ChildOf, EntityID>(unit)
                .Add<InventorySlotIndex, int>(slotIndex);
    }
}