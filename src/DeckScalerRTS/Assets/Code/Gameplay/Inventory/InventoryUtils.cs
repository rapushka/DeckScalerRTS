using System.Collections.Generic;
using System.Linq;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public static class InventoryUtils
    {
        private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

        private static EntityIndex<GameScope, InventorySlotOfUnit, EntityID> Index
            => Contexts.Instance.Get<GameScope>().GetIndex<InventorySlotOfUnit, EntityID>();

        public static Entity<GameScope> GetFirstFreeSlotOrDefault(EntityID unitID)
            => GetSlotsInOrder(unitID).FirstOrDefault(s => !s.Has<ItemInSlot>());

        /// Returns Slots of the Unit not in order
        public static IEnumerable<Entity<GameScope>> GetInventory(EntityID unitID)
            => Index.GetEntities(unitID);

        public static IEnumerable<Entity<GameScope>> GetSlotsInOrder(EntityID unitID)
        {
            var inventorySlots = Index.GetEntities(unitID);

            for (var i = 0; i < inventorySlots.Count; i++)
                yield return Context.GetInventorySlot(unitID, i);
        }

        public static void ReparentItemToSlot(EntityID itemID, EntityID slotID)
        {
            var item = itemID.GetEntity();
            var toSlot = slotID.GetEntity();

            var fromSlot = item.Get<ChildOf>().Value.GetEntity();

            var fromSlotOwnerID = fromSlot.Get<InventorySlotOfUnit>().Value;
            var toSlotOwnerID = toSlot.Get<InventorySlotOfUnit>().Value;

            if (fromSlotOwnerID != toSlotOwnerID)
            {
                Debug.LogError("TODO: Implement moving item from one unit to the other");
                return;
            }

            fromSlot.Remove<ItemInSlot>();

            TakeItemToSlot(item, toSlot);

            fromSlotOwnerID.GetEntity().AddSafely<RequestUpdateInventoryUI>();
            toSlotOwnerID.GetEntity().AddSafely<RequestUpdateInventoryUI>();
        }

        public static void TakeItemToSlot(Entity<GameScope> item, Entity<GameScope> itemSlot)
        {
            var itemID = item.ID();

            itemSlot
                .Add<ItemInSlot, EntityID>(itemID)
                ;

            item
                .Is<LyingOnGround>(false)
                .Set<Visible, bool>(false)
                .Set<ChildOf, EntityID>(itemSlot.ID())
                ;

            var slotOwner = itemSlot.Get<InventorySlotOfUnit>().Value.GetEntity();
            slotOwner
                .AddSafely<RequestUpdateInventoryUI>();
        }
    }
}