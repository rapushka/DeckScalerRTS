using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class StopSelectionSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _cursors
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .Or<SelectJustUp>()
                .Or<SelectClicked>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionRect>()
                .And<Selecting>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(2);

        public void Execute()
        {
            foreach (var _ in _cursors)
            foreach (var selection in _selectionViews.GetEntities(_buffer))
            {
                var view = selection.Get<SelectionRect>().Value;
                view.Hide();

                selection.Is<Selecting>(false);
            }
        }
    }
}