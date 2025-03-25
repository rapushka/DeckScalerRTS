using System.Collections.Generic;
using Entitas.Generic;

namespace DeckScaler
{
    public static class InventoryUtils
    {
        private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

        private static EntityIndex<GameScope, InventorySlotOfUnit, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InventorySlotOfUnit, EntityID>();

        public static IEnumerable<Entity<GameScope>> GetSlotsInOrder(EntityID unitID)
        {
            var inventorySlots = Index.GetEntities(unitID);

            for (var i = 0; i < inventorySlots.Count; i++)
                yield return Context.GetInventorySlot(unitID, i);
        }
    }
}