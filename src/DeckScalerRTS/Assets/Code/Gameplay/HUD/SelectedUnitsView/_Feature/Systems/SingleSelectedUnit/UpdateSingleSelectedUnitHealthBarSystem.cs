using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateSingleSelectedUnitHealthBarSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .And<DisplayingSingleUnitSelected>()
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

                var view = uiEntity.Get<SelectedUnitUi>().Value;
                view.HealthBar.HpData = unit.GetHpData();
            }
        }
    }
}