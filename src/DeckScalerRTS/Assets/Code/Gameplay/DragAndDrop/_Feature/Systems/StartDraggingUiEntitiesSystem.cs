using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class StartDraggingUiEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                // .And<OverUI>()
                .And<SelectJustDown>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _uis
            = GroupBuilder<UiScope>
                .With<Draggable>()
                .And<HoveredByMouse>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _inputs)
            foreach (var ui in _uis)
            {
                ui.Is<Dragging>(true);
            }
        }
    }
}