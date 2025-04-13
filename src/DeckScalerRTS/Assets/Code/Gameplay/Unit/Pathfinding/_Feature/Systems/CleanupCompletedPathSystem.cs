using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CleanupCompletedPathSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<PathSeeker>()
                .And<Path>()
                .Without<MoveToPosition>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity
                    .Remove<Path>()
                    .Is<CalculatingPath>(false)
                    ;
            }
        }
    }
}