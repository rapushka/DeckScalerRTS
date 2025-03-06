using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnSelectionEndedSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _cursors
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .Or<SelectJustUp>()
                .Or<SelectClicked>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionView>()
                .And<Selecting>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(2);

        public void Execute()
        {
            foreach (var _ in _cursors)
            foreach (var selection in _selectionViews.GetEntities(_buffer))
            {
                selection
                    .Is<SelectionDragEnded>(true)
                    .Is<Selecting>(false)
                    ;
            }
        }
    }
}