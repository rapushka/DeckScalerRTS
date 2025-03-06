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
                .With<SelectionRect>()
                .Build();

        private static Camera UiCamera => ServiceLocator.Resolve<ICameraService>().UiCamera;

        public void Execute()
        {
            foreach (var cursor in _cursors)
            foreach (var selection in _selectionViews)
            {
                var mouseWorldPosition = cursor.Get<MouseWorldPosition>().Value;
                var mouseScreenPosition = UiCamera.WorldToScreenPoint(mouseWorldPosition);

                selection.Is<Selecting>(true);

                var view = selection.Get<SelectionRect>().Value;
                view.Show(mouseScreenPosition);
            }
        }
    }
}