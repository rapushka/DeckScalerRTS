using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class CalculateSelectionRectSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _cursors
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .And<SelectDown>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionView>()
                .And<Selecting>()
                .Build();

        private static ICameraService Camera => ServiceLocator.Resolve<ICameraService>();

        public void Execute()
        {
            foreach (var cursor in _cursors)
            foreach (var selection in _selectionViews)
            {
                var mouseWorldPosition = cursor.Get<MouseWorldPosition, Vector2>();
                var cursorPosition = Camera.WorldToScreen(mouseWorldPosition);

                var origin = selection.Get<SelectionOrigin>().Value;

                var rect = new Rect
                {
                    size = new(
                        x: (origin.x - cursorPosition.x).Abs(),
                        y: (origin.y - cursorPosition.y).Abs()
                    ),
                    center = (origin + cursorPosition) / 2,
                };
                selection.Set<SelectionRect, Rect>(rect);
            }
        }
    }
}