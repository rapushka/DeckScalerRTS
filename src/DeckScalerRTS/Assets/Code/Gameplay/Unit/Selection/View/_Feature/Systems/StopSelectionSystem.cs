using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class StopSelectionSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionView>()
                .And<SelectionDragEnded>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(2);

        public void Execute()
        {
            foreach (var selection in _selectionViews.GetEntities(_buffer))
                selection.Get<SelectionView>().Value.Hide();
        }
    }
}