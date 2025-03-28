using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CleanupDroppedSystem : ICleanupSystem
    {
        private readonly IGroup<Entity<UiScope>> _entities
            = GroupBuilder<UiScope>
                .With<Dropped>()
                .Build();

        private readonly List<Entity<UiScope>> _buffer = new(16);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Is<Dropped>(false);
        }
    }
}