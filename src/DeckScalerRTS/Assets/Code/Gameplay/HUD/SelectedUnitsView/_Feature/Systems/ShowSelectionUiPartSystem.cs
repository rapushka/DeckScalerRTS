using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ShowSelectionUiPartSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .Without<UiVisible>()
                .Build();

        private readonly List<Entity<UiScope>> _buffer = new(2);

        public void Execute()
        {
            foreach (var uiEntity in _uiEntities.GetEntities(_buffer))
            {
                _selectedUnits.count.SwitchUnitsCount(
                    onSingle: uiEntity.Get<SelectedUnitUi>().Value.ShowSingle,
                    onMultiple: uiEntity.Get<SelectedUnitUi>().Value.ShowMultiple,
                    onNone: () => { }
                );
                uiEntity.Is<UiVisible>(true);
            }
        }
    }
}