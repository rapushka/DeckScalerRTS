using System.Collections.Generic;
using System.Linq;
using Entitas.Generic;

namespace DeckScaler
{
    public static class InventoryUtils
    {
        private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

        private static EntityIndex<GameScope, InventorySlotOfUnit, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InventorySlotOfUnit, EntityID>();

        public static Entity<GameScope> GetFirstFreeSlotOrDefault(EntityID unitID)
            => GetSlotsInOrder(unitID).FirstOrDefault(s => !s.Has<ItemInSlot>());

        public static IEnumerable<Entity<GameScope>> GetInventory(EntityID unitID)
            => Index.GetEntities(unitID);

        public static IEnumerable<Entity<GameScope>> GetSlotsInOrder(EntityID unitID)
        {
            var inventorySlots = Index.GetEntities(unitID);

            for (var i = 0; i < inventorySlots.Count; i++)
                yield return Context.GetInventorySlot(unitID, i);
        }
    }
}