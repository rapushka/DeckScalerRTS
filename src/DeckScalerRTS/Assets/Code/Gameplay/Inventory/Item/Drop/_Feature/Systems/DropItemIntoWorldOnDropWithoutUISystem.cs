using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class DropItemIntoWorldOnDropWithoutUISystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _inputs
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .Without<OverUI>()
                .Build();

        private readonly IGroup<Entity<UiScope>> _draggedItems
            = GroupBuilder<UiScope>
                .With<UiOfItem>()
                .And<Dropped>()
                .Build();

        public void Execute()
        {
            foreach (var _ in _inputs)
            foreach (var item in _draggedItems)
            {
                Debug.Log($"TODO: Drop {item}");
            }
        }
    }
}