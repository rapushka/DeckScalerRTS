using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class StartSelectionSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _cursors
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<MouseWorldPosition>()
                .And<SelectJustDown>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionView>()
                .And<SelectionRect>()
                .Build();

        private static ICameraService Camera => ServiceLocator.Resolve<ICameraService>();

        public void Execute()
        {
            foreach (var cursor in _cursors)
            foreach (var selection in _selectionViews)
            {
                var mouseWorldPosition = cursor.Get<MouseWorldPosition>().Value;
                var mouseScreenPosition = Camera.WorldToScreen(mouseWorldPosition);

                selection
                    .Is<Selecting>(true)
                    .Set<SelectionOrigin, Vector2>(mouseScreenPosition)
                    ;

                var view = selection.Get<SelectionView>().Value;
                view.Show();
            }
        }
    }
}