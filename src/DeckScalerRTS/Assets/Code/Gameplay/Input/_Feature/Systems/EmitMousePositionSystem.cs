using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class EmitMousePositionSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseDelta>()
                .And<MouseWorldPosition>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        private static Camera MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;

        public void Execute()
        {
            foreach (var inputEntity in _inputs)
            {
                var lastMousePosition = inputEntity.Get<MouseScreenPosition, Vector2>();

                var mouseScreenPosition = Input.MouseScreenPosition;
                var mouseWorldPosition = MainCamera.ScreenToWorldPoint(mouseScreenPosition);

                var currentMousePosition = mouseWorldPosition.Truncate();

                var delta = (mouseScreenPosition - lastMousePosition) / 50;
                inputEntity
                    .Set<MouseScreenPosition, Vector2>(mouseScreenPosition)
                    .Set<MouseWorldPosition, Vector2>(currentMousePosition)
                    .Set<MouseDelta, Vector2>(delta)
                    .Is<JustClickedSelect>(Input.JustClickedSelect)
                    .Is<DraggingCamera>(Input.IsDragButtonPressed)
                    ;
            }
        }
    }
}