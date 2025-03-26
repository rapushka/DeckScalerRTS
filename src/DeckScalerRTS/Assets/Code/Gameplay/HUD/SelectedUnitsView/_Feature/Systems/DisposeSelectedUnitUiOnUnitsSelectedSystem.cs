using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DisposeSelectedUnitUiOnUnitsSelectedSystem : IExecuteSystem
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
                var ui = uiEntity.Get<SelectedUnitUi>().Value;
                ui.Dispose();
            }
        }
    }
}