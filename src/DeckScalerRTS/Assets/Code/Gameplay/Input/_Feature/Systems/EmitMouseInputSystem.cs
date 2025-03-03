using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class EmitMouseInputSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _input
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<AccumulatedMouseMovement>()
                .And<MouseWorldPosition>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        private static Camera MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;

        public void Execute()
        {
            foreach (var inputEntity in _input)
            {
                var mouseScreenPosition = Input.MouseScreenPosition;
                var mouseWorldPosition = MainCamera.ScreenToWorldPoint(mouseScreenPosition);

                inputEntity
                    .Set<MouseWorldPosition, Vector2>(mouseWorldPosition)
                    .Set<AccumulatedMouseMovement, Vector2>(Input.MouseMovementDelta)
                    .Is<JustClickedSelect>(Input.JustClickedSelect)
                    ;
            }
        }
    }
}