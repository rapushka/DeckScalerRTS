using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class StopSelectionSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _cursors
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<SelectJustUp>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionRect>()
                .And<Selecting>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _cursors)
            foreach (var selection in _selectionViews)
            {
                var view = selection.Get<SelectionRect>().Value;
                view.Hide();
            }
        }
    }
}