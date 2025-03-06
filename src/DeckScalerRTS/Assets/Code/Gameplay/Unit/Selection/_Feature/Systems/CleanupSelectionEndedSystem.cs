using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CleanupSelectionEndedSystem : ICleanupSystem
    {
        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionView>()
                .And<SelectionDragEnded>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(2);

        public void Cleanup()
        {
            foreach (var selection in _selectionViews.GetEntities(_buffer))
                selection.Is<SelectionDragEnded>(false);
        }
    }
}