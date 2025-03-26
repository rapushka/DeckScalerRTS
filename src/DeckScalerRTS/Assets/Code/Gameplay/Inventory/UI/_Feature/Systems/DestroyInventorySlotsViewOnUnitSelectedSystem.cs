using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroyInventorySlotsViewOnUnitSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SelectUnitEvent>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _slotViews
            = GroupBuilder<UiScope>
                .With<InventoryItemSlotUiView>()
                .And<ItemSprite>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var slotView in _slotViews)
                slotView.Is<Destroy>(true);
        }
    }
}