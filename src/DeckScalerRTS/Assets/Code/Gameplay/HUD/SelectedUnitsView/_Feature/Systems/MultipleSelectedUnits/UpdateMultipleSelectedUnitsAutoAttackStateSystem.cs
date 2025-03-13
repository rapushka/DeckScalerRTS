using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateMultipleSelectedUnitsAutoAttackStateSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .And<DisplayingMultipleUnitsSelected>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        public void Execute()
        {
            foreach (var ui in _uiEntities)
            {
                var commonState = _selectedUnits.GetCommonAutoAttackState();
                ui.Get<SelectedUnitUi>().Value.AutoAttackState = commonState;
            }
        }
    }
}