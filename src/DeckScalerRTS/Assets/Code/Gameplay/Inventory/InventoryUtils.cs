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

            if (fromSlot.ID() == slotID)
                return;

            var fromSlotOwnerID = fromSlot.Get<InventorySlotOfUnit>().Value;
            var toSlotOwnerID = toSlot.Get<InventorySlotOfUnit>().Value;

            if (fromSlotOwnerID != toSlotOwnerID)
            {
                Debug.LogError("TODO: Implement moving item from one unit to the other");
                return;
            }

            if (!toSlot.Has<ItemInSlot>())
            {
                fromSlot.Remove<ItemInSlot>();
                TakeItemToSlot(item, toSlot);
            }
            else
                SwapItemsInSlots(fromSlot, toSlot);

            fromSlotOwnerID.GetEntity().AddSafely<RequestUpdateInventoryUI>();
            toSlotOwnerID.GetEntity().AddSafely<RequestUpdateInventoryUI>();
        }

        public static void TakeItemToSlot(Entity<GameScope> item, Entity<GameScope> slot)
        {
            var itemID = item.ID();

            slot
                .Add<ItemInSlot, EntityID>(itemID)
                ;

            item
                .Is<LyingOnGround>(false)
                .Set<Visible, bool>(false)
                .Set<ChildOf, EntityID>(slot.ID())
                ;

            var slotOwner = slot.Get<InventorySlotOfUnit>().Value.GetEntity();
            slotOwner
                .AddSafely<RequestUpdateInventoryUI>();
        }

        private static void SwapItemsInSlots(Entity<GameScope> firstSlot, Entity<GameScope> secondSlot)
        {
            var firstItem = firstSlot.Pop<ItemInSlot, EntityID>().GetEntity();
            var secondItem = secondSlot.Pop<ItemInSlot, EntityID>().GetEntity();

            TakeItemToSlot(firstItem, secondSlot);
            TakeItemToSlot(secondItem, firstSlot);
        }
    }

    public static class InventoryExtensions
    {
        public static bool TryGetOwnerUnitOfItem(this Entity<GameScope> item, out EntityID? unitID)
        {
            unitID = null;

            if (!item.TryGet<ChildOf, EntityID>(out var parentID))
                return false;

            var parent = parentID.GetEntity();
            if (!parent.TryGet<InventorySlotOfUnit, EntityID>(out var tmp))
                return false;

            unitID = tmp;
            return true;
        }

        public static EntityID GetOwnerUnitOfItem(this Entity<GameScope> item)
        {
            var slot = item.GetSlotOfItem().GetEntity();
            var ownerID = slot.Get<InventorySlotOfUnit>().Value;

            return ownerID;
        }

        public static EntityID GetSlotOfItem(this Entity<GameScope> item)
            => item.Get<ChildOf>().Value;
    }
}