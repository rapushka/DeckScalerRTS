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

                var isHoveringUnit = _hoveredEntities.Any(e => e.Has<UnitID>());
                var isHoveringAlly = _hoveredEntities.Any(e => e.Is<OnPlayerSide>());

                if (!isHoveringUnit)
                {
                    Set("drop");
                    continue;
                }

                if (!isHoveringAlly)
                {
                    Set("items can be used only on allies", false);
                    continue;
                }

                var item = itemUI.Get<UiOfItem>().Value.GetEntity();

                if (item.Is<Drink>())
                    Set("use");
                else
                    Set("trinkets can't be used", false);

                continue;

                void Set(string text, bool isValid = true)
                {
                    itemUI
                        .Set<UseComment, string>(text)
                        .Set<ValidUsage, bool>(isValid)
                        ;
                }
            }
        }
    }
}