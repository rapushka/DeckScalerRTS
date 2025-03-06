using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DrawSelectionAreaViewSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _cursors
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .And<SelectDown>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionView>()
                .And<Selecting>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _cursors)
            foreach (var selection in _selectionViews)
            {
                var rect = selection.Get<SelectionRect>();

                var view = selection.Get<SelectionView>().Value;
                view.UpdatePositions(rect.Value);
            }
        }
    }
}