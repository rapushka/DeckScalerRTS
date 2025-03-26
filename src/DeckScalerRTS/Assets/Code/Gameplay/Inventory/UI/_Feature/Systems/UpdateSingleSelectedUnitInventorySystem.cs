using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateSingleSelectedUnitInventorySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .And<DisplayingSingleUnitSelected>()
                .And<UiVisible>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        public void Execute()
        {
            foreach (var uiEntity in _uiEntities)
            {
                var unit = _selectedUnits.GetSingleEntity();

                var view = uiEntity.Get<SelectedUnitUi>().Value.SingleView;
                view.UpdateInventory(unit);
            }
        }
    }
}