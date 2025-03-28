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
                .And<OverUI>()
                .And<SelectDown>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _slotUIs
            = GroupBuilder<UiScope>
                .With<Dragging>()
                .Build();

        public void Execute()
        {
            foreach (var input in _inputs)
            foreach (var slot in _slotUIs)
            {
                var mousePosition = input.Get<MouseScreenPosition>().Value;

                slot.Set<ScreenPosition, Vector2>(mousePosition);
            }
        }
    }
}