using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class DragCameraSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .And<DragCameraOrigin>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        private static Camera MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;

        public void Execute()
        {
            if (!Input.IsDragButtonPressed)
                return;

            foreach (var inputEntity in _inputs)
            {
                var origin = inputEntity.Get<DragCameraOrigin>().Value;

                var mouseWorldPosition = inputEntity.Get<MouseWorldPosition, Vector2>();
                var cameraWorldPosition = MainCamera.transform.position.Truncate();
                var delta = mouseWorldPosition - cameraWorldPosition;

                MainCamera.transform.position = (origin - delta).Extend(-10);
            }
        }
    }
}