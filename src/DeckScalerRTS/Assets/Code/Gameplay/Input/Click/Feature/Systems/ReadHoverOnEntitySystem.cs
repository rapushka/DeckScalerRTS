using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ReadHoverOnEntitySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<Hoverable>()
                .And<Collider>()
                .Build();

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var hoverable in _entities)
            {
                var mouseWorldPosition = input.Get<MouseWorldPosition>().Value;
                var entityCollider = hoverable.Get<Collider>().Value;
                var overlaps = entityCollider.OverlapPoint(mouseWorldPosition);

                hoverable.Is<Hovered>(overlaps);
            }
        }
    }
}