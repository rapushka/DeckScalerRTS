using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    using GameContext = ScopeContext<GameScope>;

    public class UnitInventorySlotPrimaryIndex
    {
        public const string SlotPosition = nameof(SlotPosition);

        private readonly GameContext _context;

        public UnitInventorySlotPrimaryIndex(GameContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.AddEntityIndex(
                new PrimaryEntityIndex<Entity<GameScope>, Key>(
                    name: SlotPosition,
                    group: GroupBuilder<GameScope>
                        .With<InventorySlotOfUnit>()
                        .And<InventorySlotIndex>()
                        .Build(),
                    getKey:
                    GetKey,
                    comparer:
                    new Comparer()
                )
            );
        }

        private Key GetKey(Entity<GameScope> entity, IComponent component)
            => new(
                unitID: (component as InventorySlotOfUnit)?.Value ?? entity.Get<InventorySlotOfUnit>().Value,
                slotIndex: (component as InventorySlotIndex)?.Value ?? entity.Get<InventorySlotIndex>().Value
            );

        private class Comparer : IEqualityComparer<Key>
        {
            public bool Equals(Key x, Key y)
                => x.UnitID == y.UnitID
                    && x.SlotIndex == y.SlotIndex;

            public int GetHashCode(Key obj)
                => HashCode.Combine((int)obj.UnitID, obj.SlotIndex);
        }

        public struct Key
        {
            public readonly EntityID UnitID;
            public readonly int SlotIndex;

            public Key(EntityID unitID, int slotIndex)
            {
                UnitID = unitID;
                SlotIndex = slotIndex;
            }
        }
    }

    public static class SlotPositionIndexExtension
    {
        public static bool TryGetInventorySlot(this GameContext context, int index, EntityID unitID, out Entity<GameScope> unit)
        {
            unit = context.GetInventorySlotOrDefault(unitID, index);
            return unit is not null;
        }

        public static Entity<GameScope> GetInventorySlot(this GameContext context, EntityID unitID, int index)
            => context.GetInventorySlotOrDefault(unitID, index) ?? throw new NullReferenceException();

        public static Entity<GameScope> GetInventorySlotOrDefault(this GameContext context, EntityID unitID, int index)
        {
            var entityIndex = context.GetEntityIndex(UnitInventorySlotPrimaryIndex.SlotPosition);
            var gameIndex = (PrimaryEntityIndex<Entity<GameScope>, UnitInventorySlotPrimaryIndex.Key>)entityIndex;

            return gameIndex.GetEntity(new(unitID, index));
        }
    }
}