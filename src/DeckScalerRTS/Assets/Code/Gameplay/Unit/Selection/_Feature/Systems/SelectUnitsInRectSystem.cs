using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SelectUnitsInRectSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _selectionViews
            = GroupBuilder<GameScope>
                .With<SelectionView>()
                .And<SelectionDragEnded>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _units
            = GroupBuilder<GameScope>
                .With<UnitID>()
                .And<WorldPosition>()
                .Build();

        private static ICameraService Camera => ServiceLocator.Resolve<ICameraService>();

        public void Execute()
        {
            foreach (var selection in _selectionViews)
            foreach (var unit in _units)
            {
                var rect = selection.Get<SelectionRect>().Value;
                var unitWorldPosition = unit.Get<WorldPosition>().Value;

                var unitScreenPosition = Camera.WorldToScreen(unitWorldPosition);

                if (rect.Contains(unitScreenPosition))
                    UnitUtils.Select(unit);
            }
        }
    }
}