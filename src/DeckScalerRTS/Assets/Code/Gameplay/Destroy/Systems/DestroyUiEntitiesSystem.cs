using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class DestroyUiEntitiesSystem : ICleanupSystem
    {
        private readonly IGroup<Entity<UiScope>> _entities
            = GroupBuilder<UiScope>
                .With<Destroy>()
                .Build();

        private readonly List<Entity<UiScope>> _buffer = new(128);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.TryGet<UiView, UiEntityBehaviour>(out var view))
                {
                    view.Unregister();
                    view.DestroyObject();
                }

                entity.Destroy();
            }
        }
    }
}