using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class HideSelectionUiIfNoUnitsSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .Build();

        public void Execute()
        {
            if (_selectedUnits.Any())
                return;

            foreach (var ui in _uiEntities)
            {
                var view = ui
                    .Is<DisplayingSingleUnitSelected>(false)
                    .Is<DisplayingMultipleUnitsSelected>(false)
                    .Is<Displaying>(false)
                    .Get<SelectedUnitUi>().Value;

                view.Hide();
            }
        }
    }
}