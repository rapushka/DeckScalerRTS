using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class MoveDraggingItemsToContainerSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _draggingSlots
            = GroupBuilder<UiScope>
                .With<UiOfItem>()
                .And<StartDragging>()
                .Build();

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static GameplayHUDPage HUD => UiMediator.GetPage<GameplayHUDPage>();

        public void Execute()
        {
            foreach (var slot in _draggingSlots)
            {
                var container = HUD.Inventory.DraggingContainer;
                slot.Set<UiParent, RectTransform>(container);
            }
        }
    }
}