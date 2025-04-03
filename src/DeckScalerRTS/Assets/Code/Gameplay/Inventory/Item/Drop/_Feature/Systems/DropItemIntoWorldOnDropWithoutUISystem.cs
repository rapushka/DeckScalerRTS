using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DropItemIntoWorldOnDropWithoutUISystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .Without<OverUI>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _draggedItems
            = GroupBuilder<UiScope>
                .With<UiOfItem>()
                .And<Dropped>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _inputs)
            foreach (var itemUI in _draggedItems)
            {
                var itemID = itemUI.Get<UiOfItem>().Value;
                var item = itemID.GetEntity();
                var unit = item.GetOwnerUnitOfItem().GetEntity();

                unit
                    .Add<DropItemToWorldOrder, EntityID>(itemID)
                    .Add<ProcessingItemDrop>()
                    ;
            }
        }
    }
}