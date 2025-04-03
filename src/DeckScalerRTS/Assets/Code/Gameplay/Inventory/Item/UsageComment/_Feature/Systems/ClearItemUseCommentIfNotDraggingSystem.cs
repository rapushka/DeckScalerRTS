using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ClearItemUseCommentIfNotDraggingSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<UiScope>> _items
            = GroupBuilder<UiScope>
                .With<UiOfItem>()
                .Without<Dragging>()
                .Build();

        public void Execute()
        {
            foreach (var itemUI in _items)
            {
                if (itemUI.Get<UseComment, string>() == string.Empty)
                    continue;

                itemUI
                    .Set<UseComment, string>(string.Empty)
                    .Set<ValidUsage, bool>(true)
                    ;
            }
        }
    }
}