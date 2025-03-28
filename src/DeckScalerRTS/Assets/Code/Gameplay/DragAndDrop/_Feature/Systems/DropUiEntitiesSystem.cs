using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DropUiEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<SelectJustUp>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _uis
            = GroupBuilder<UiScope>
                .With<Dragging>()
                .Build();

        private readonly List<Entity<UiScope>> _buffer = new(16);

        public void Execute()
        {
            foreach (var _ in _inputs)
            foreach (var ui in _uis.GetEntities(_buffer))
            {
                ui
                    .Is<Dragging>(false)
                    .Is<Dropped>(true)
                    ;
            }
        }
    }
}