using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class StartDraggingCameraSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        public void Execute()
        {
            if (Input.DragCameraButton is not ButtonState.JustDown)
                return;

            foreach (var inputEntity in _inputs)
            {
                var mouseWorldPosition = inputEntity.Get<MouseWorldPosition, Vector2>();
                inputEntity.Set<DragCameraOrigin, Vector2>(mouseWorldPosition);
            }
        }
    }
}