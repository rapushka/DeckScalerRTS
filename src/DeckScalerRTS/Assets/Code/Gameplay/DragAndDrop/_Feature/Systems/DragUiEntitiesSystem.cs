using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class DragUiEntitiesSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<SelectDown>()
                .And<MouseScreenPosition>()
                .And<PreviousMouseScreenPosition>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _draggables
            = GroupBuilder<UiScope>
                .With<Dragging>()
                .Build();

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var draggable in _draggables)
            {
                var mousePosition = input.Get<MouseScreenPosition>().Value;

                draggable.Set<ScreenPosition, Vector2>(mousePosition);
            }
        }
    }
}