using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class DropItemWhenCloseToTargetSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<WorldPosition>()
                .And<MoveToPosition>()
                .And<DropItemOnPositionOrder>()
                .Build();

        private static EntityIndex<UiScope, UiOfInventorySlot, EntityID> InventorySlotIndex
            => Contexts.Instance.Get<UiScope>().GetIndex<UiOfInventorySlot, EntityID>();

        private static EntityIndex<UiScope, UiOfItem, EntityID> UiOfItemIndex
            => Contexts.Instance.Get<UiScope>().GetIndex<UiOfItem, EntityID>();

        private static UnitsConfig.CommonBalance UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units.Common;

        private readonly List<Entity<GameScope>> _buffer = new(16);

        private static Entity<GameScope> CurrentLevel
            => Contexts.Instance.Get<GameScope>().Unique.GetEntity<CurrentLevel>();

        public void Execute()
        {
            foreach (var unit in _units.GetEntities(_buffer))
            {
                var unitPosition = unit.Get<WorldPosition, Vector2>();
                var targetPosition = unit.Get<DropItemOnPositionOrder, Vector2>();

                var distanceToItem = unitPosition.DistanceTo(targetPosition);

                if (distanceToItem > UnitsConfig.ItemsInteractRadius)
                    continue;

                DropItem(unit, targetPosition);
            }
        }

        private static void DropItem(Entity<GameScope> unit, Vector2 targetPosition)
        {
            var itemID = unit.Get<DropItemToWorldOrder>().Value;
            var itemToDrop = itemID.GetEntity();

            unit
                .Remove<MoveToPosition>()
                .Remove<DropItemToWorldOrder>()
                .Remove<DropItemOnPositionOrder>()
                .Is<DroppingDrink>(false)
                ;

            CreateEntity.OneFrame()
                .Add<ItemDroppedEvent, EntityID>(itemID)
                ;

            var slot = itemToDrop.GetSlotOfItem().GetEntity();
            slot.Remove<ItemInSlot>();

            var slotUIs = InventorySlotIndex.GetEntities(slot.ID());
            foreach (var slotUI in slotUIs)
                slotUI.Remove<ItemInSlot>();

            var itemUIs = UiOfItemIndex.GetEntities(itemID);
            foreach (var itemUI in itemUIs)
                itemUI.Is<Destroy>(true);

            itemToDrop
                .Is<LyingOnGround>(true)
                .Set<Visible, bool>(true)
                .Set<WorldPosition, Vector2>(targetPosition)
                .Set<ChildOf, EntityID>(CurrentLevel.ID())
                ;

            unit.AddSafely<RequestUpdateInventoryUI>();
        }
    }
}