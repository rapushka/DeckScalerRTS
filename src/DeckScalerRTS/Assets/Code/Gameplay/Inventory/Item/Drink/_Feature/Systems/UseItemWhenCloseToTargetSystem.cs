using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UseItemWhenCloseToTargetSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<WorldPosition>()
                .And<MoveToPosition>()
                .And<UseDrinkOn>()
                .Build();

        private static EntityIndex<UiScope, UiOfInventorySlot, EntityID> InventorySlotIndex
            => Contexts.Instance.Get<UiScope>().GetIndex<UiOfInventorySlot, EntityID>();

        private static EntityIndex<UiScope, UiOfItem, EntityID> UiOfItemIndex
            => Contexts.Instance.Get<UiScope>().GetIndex<UiOfItem, EntityID>();

        private static UnitsConfig.CommonBalance UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units.Common;

        private static IAffectFactory AffectFactory => ServiceLocator.Resolve<IAffectFactory>();

        private readonly List<Entity<GameScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var ownerUnit in _units.GetEntities(_buffer))
            {
                var unitPosition = ownerUnit.Get<WorldPosition, Vector2>();
                var targetUnit = ownerUnit.Get<UseDrinkOn, EntityID>().GetEntity();
                var targetPosition = targetUnit.Get<WorldPosition>().Value;

                var distanceToTargetUnit = unitPosition.DistanceTo(targetPosition);

                if (distanceToTargetUnit > UnitsConfig.ItemsInteractRadius)
                    continue;

                DropItem(ownerUnit, targetUnit);
            }
        }

        private static void DropItem(Entity<GameScope> ownerUnit, Entity<GameScope> targetUnit)
        {
            var itemID = ownerUnit.Get<DropItemToWorldOrder>().Value;
            var itemToUse = itemID.GetEntity();

            ownerUnit
                .Remove<MoveToPosition>()
                .Remove<DropItemToWorldOrder>()
                .Remove<UseDrinkOn>()
                ;

            var slot = itemToUse.GetSlotOfItem().GetEntity();
            slot.Remove<ItemInSlot>();

            var slotUIs = InventorySlotIndex.GetEntities(slot.ID());
            foreach (var slotUI in slotUIs)
                slotUI.Remove<ItemInSlot>();

            var itemUIs = UiOfItemIndex.GetEntities(itemID);
            foreach (var itemUI in itemUIs)
                itemUI.Is<Destroy>(true);

            itemToUse
                .Is<Destroy>(true)
                ;

            var affectConfig = itemToUse.Get<AffectOnUsed>().Value;
            AffectFactory.Create(affectConfig, ownerUnit, targetUnit);

            ownerUnit.AddSafely<RequestUpdateInventoryUI>();
        }
    }
}