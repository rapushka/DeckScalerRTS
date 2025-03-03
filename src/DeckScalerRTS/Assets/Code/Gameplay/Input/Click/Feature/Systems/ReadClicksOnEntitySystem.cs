using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ReadClicksOnEntitySystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<JustClickedSelect>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _clickables
            = GroupBuilder<GameScope>
                .With<Clickable>()
                .And<Collider>()
                .Build();

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var clickable in _clickables)
            {
                var mouseWorldPosition = input.Get<MouseWorldPosition>().Value;
                var entityCollider = clickable.Get<Collider>().Value;
                var overlaps = entityCollider.OverlapPoint(mouseWorldPosition);

                if (overlaps)
                    clickable.Is<Clicked>(true);
            }
        }
    }
}