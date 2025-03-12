using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class LoadSelectedUnitPortraitSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .And<DisplayingSingleUnitSelected>()
                .Without<Visible>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectedUnits
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<SelectedUnit>()
                .Build();

        private static UnitsConfig UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units;

        public void Execute()
        {
            foreach (var uiEntity in _uiEntities)
            {
                var unit = _selectedUnits.GetSingleEntity();
                var id = unit.Get<UnitID, UnitIDRef>();
                var unitConfig = UnitsConfig.GetConfig(id);

                var selectedUnitsUiView = uiEntity.Get<SelectedUnitUi>().Value;
                selectedUnitsUiView.SingleView.PortraitView.sprite = unitConfig.Portrait;
            }
        }
    }
}