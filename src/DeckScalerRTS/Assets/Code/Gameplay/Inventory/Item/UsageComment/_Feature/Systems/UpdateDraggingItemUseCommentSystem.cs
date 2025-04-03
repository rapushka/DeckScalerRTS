using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class UpdateDraggingItemUseCommentSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _draggingItems
            = GroupBuilder<UiScope>
                .With<UiOfItem>()
                .And<Dragging>()
                .Build();

        private readonly IGroup<Entity<GameScope>> _hoveredEntities
            = GroupBuilder<GameScope>
                .With<Hovered>()
                .Build();

        public void Execute()
        {
            foreach (var itemUI in _draggingItems)
            foreach (var input in _inputs)
            {
                if (input.Is<OverUI>())
                {
                    itemUI
                        .Set<UseComment, string>(string.Empty)
                        .Set<ValidUsage, bool>(true)
                        ;
                    continue;
                }

                var hoveringUnits = _hoveredEntities.Any(e => e.Has<UnitID>());
                var hoveringAlly = _hoveredEntities.Any(e => e.Is<OnPlayerSide>());

                if (hoveringUnits && !hoveringAlly)
                {
                    itemUI
                        .Set<UseComment, string>("items can be used only on allies")
                        .Set<ValidUsage, bool>(false)
                        ;
                }
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse - it's here for vibes
                else if (hoveringUnits && hoveringAlly)
                {
                    itemUI
                        .Set<UseComment, string>("use")
                        .Set<ValidUsage, bool>(true)
                        ;
                }
                else
                {
                    itemUI
                        .Set<UseComment, string>("drop")
                        .Set<ValidUsage, bool>(true)
                        ;
                }
            }
        }
    }
}