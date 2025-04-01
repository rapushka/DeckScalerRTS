using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class LoadSingleSelectedUnitPortraitSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _uiEntities
            = GroupBuilder<UiScope>
                .With<SelectedUnitUi>()
                .And<DisplayingSingleUnitSelected>()
                .Without<Displaying>()
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

                var view = uiEntity.Get<SelectedUnitUi>().Value.SingleView;
                view.PortraitView.sprite = unitConfig.Portrait;
            }
        }
    }
}