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
                .And<MouseWorldPosition>()
                .Build();

        private static IInputService Input => ServiceLocator.Resolve<IInputService>();

        private static Camera MainCamera => ServiceLocator.Resolve<ICameraService>().MainCamera;

        public void Execute()
        {
            foreach (var inputEntity in _inputs)
            {
                var mouseScreenPosition = Input.MouseScreenPosition;
                var mouseWorldPosition = MainCamera.ScreenToWorldPoint(mouseScreenPosition);

                inputEntity
                    .Set<MouseWorldPosition, Vector2>(mouseWorldPosition.Truncate())
                    .Is<JustClickedSelect>(Input.JustClickedSelect)
                    ;
            }
        }
    }
}