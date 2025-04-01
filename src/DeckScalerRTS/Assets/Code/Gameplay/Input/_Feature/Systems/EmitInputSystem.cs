using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class EmitInputSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        private static ICameraService Camera => ServiceLocator.Resolve<ICameraService>();

        public void Execute()
        {
            foreach (var inputEntity in _inputs)
            {
                var mouseScreenPosition = Input.MouseScreenPosition;
                var mouseWorldPosition = Camera.ScreenToWorld(mouseScreenPosition);

                if (inputEntity.TryGet<MouseScreenPosition, Vector2>(out var prevPosition))
                    inputEntity.Set<PreviousMouseScreenPosition, Vector2>(prevPosition);

                inputEntity
                    .Set<MouseWorldPosition, Vector2>(mouseWorldPosition)
                    .Set<MouseScreenPosition, Vector2>(mouseScreenPosition)
                    .Is<SelectClicked>(Input.SelectButton is ButtonState.Clicked)
                    .Is<SelectJustDown>(Input.SelectButton is ButtonState.JustDown)
                    .Is<SelectDown>(Input.SelectButton is ButtonState.Down)
                    .Is<SelectJustUp>(Input.SelectButton is ButtonState.JustUp)
                    .Is<OverUI>(Input.IsMouseOverUI)
                    ;
            }
        }
    }
}