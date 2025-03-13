using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateMultipleSelectedUnitsHealthBarSystem : IExecuteSystem
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
                var minHealth = (HpData?)null;

                foreach (var unit in _selectedUnits)
                {
                    var hpData = unit.GetHpData();

                    if (minHealth is null || minHealth!.Value.Health > hpData.Health)
                        minHealth = hpData;
                }

                ui.Get<SelectedUnitUi>().Value.HealthBar.HpData = minHealth!.Value.WithFormat("min HP: {0}");
            }
        }
    }
}