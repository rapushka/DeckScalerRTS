using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class DrawSelectionRectSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _cursors
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .And<SelectDown>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionRect>()
                .And<Selecting>()
                .And<SelectionWorldOrigin>()
                .Build();

        private static Camera UiCamera => ServiceLocator.Resolve<ICameraService>().UiCamera;

        public void Execute()
        {
            foreach (var cursor in _cursors)
            foreach (var selection in _selectionViews)
            {
                var mouseWorldPosition = cursor.Get<MouseWorldPosition, Vector2>();
                // var mouseScreenPosition = mouseWorldPosition;
                var mouseScreenPosition = UiCamera.WorldToScreenPoint(mouseWorldPosition);

                var view = selection.Get<SelectionRect>().Value;
                view.UpdatePositions(mouseScreenPosition);
            }
        }
    }
}