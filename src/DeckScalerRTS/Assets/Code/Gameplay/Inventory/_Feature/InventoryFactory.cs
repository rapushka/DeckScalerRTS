using Entitas.Generic;

namespace DeckScaler
{
    public interface IInventoryFactory : IService
    {
        Entity<GameScope> CreateSlot(EntityID unit);
    }

    public class InventoryFactory : IInventoryFactory
    {
        public Entity<GameScope> CreateSlot(EntityID unit)
            => CreateEntity.Empty()
                .Add<DebugName, string>("inventory slot")
                .Add<InventorySlot, EntityID>(unit)
                .Add<ChildOf, EntityID>(unit);
    }
}