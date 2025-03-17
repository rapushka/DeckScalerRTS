using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class ZoomCameraSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        private static Camera MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;

        public void Execute()
        {
            foreach (var _ in _inputs)
            {
                var scroll = Input.WheelScroll;
                MainCamera.orthographicSize = (MainCamera.orthographicSize - scroll).Clamp(min: 3, max: 20);
            }
        }
    }
}