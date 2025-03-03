using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class DestroyEntitiesSystem : ICleanupSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<Destroy>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(128);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.TryGet<View, EntityBehaviour>(out var view))
                {
                    view.Unregister();
                    view.DestroyObject();
                }

                entity.Destroy();
            }
        }
    }
}