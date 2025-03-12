using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateSelectionUiPartVisibilitySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SelectUnitEvent>()
                .Build();

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
            if (!_events.Any())
                return;

            foreach (var uiEntity in _uiEntities)
            {
                _selectedUnits.count.SwitchUnitsCount(
                    onSingle: () => uiEntity.Is<DisplayingSingleUnitSelected>(true),
                    onMultiple: () => uiEntity.Is<DisplayingMultipleUnitsSelected>(true)
                );
                uiEntity.Is<Visible>(false);
            }
        }
    }
}