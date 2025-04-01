using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateSelectionUiPartVisibilityOnUnitsSelectedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _events
            = GroupBuilder<GameScope>
                .With<SelectUnitEvent>()
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
                uiEntity
                    .Is<DisplayingSingleUnitSelected>(false)
                    .Is<DisplayingMultipleUnitsSelected>(false)
                    ;

                _events.count.SwitchUnitsCount(
                    onSingle: () => uiEntity.Is<DisplayingSingleUnitSelected>(true),
                    onMultiple: () => uiEntity.Is<DisplayingMultipleUnitsSelected>(true)
                );
                uiEntity.Is<Displaying>(false);
            }
        }
    }
}