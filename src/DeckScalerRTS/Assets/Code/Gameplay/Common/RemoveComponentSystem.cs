using System.Collections.Generic;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class RemoveComponentSystem<TComponent> : ICleanupSystem
        where TComponent : IComponent, IInScope<GameScope>, new()
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<TComponent>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Remove<TComponent>();
        }
    }
}