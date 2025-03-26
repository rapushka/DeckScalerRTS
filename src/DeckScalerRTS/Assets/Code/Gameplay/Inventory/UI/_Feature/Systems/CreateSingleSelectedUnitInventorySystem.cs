using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CreateSingleSelectedUnitInventorySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .And<DisplayingSingleUnitSelected>()
                .Without<UiVisible>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        private static IInventoryUIFactory Factory => ServiceLocator.Resolve<IInventoryUIFactory>();

        public void Execute()
        {
            foreach (var _ in _uiEntities)
            {
                var unit = _selectedUnits.GetSingleEntity();

                foreach (var slot in InventoryUtils.GetSlotsInOrder(unit.ID()))
                    Factory.CreateSlotView(slot);
            }
        }
    }
}