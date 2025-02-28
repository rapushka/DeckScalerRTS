using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class UpdateMousePositionSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<InputScope>> _input
            = GroupBuilder<InputScope>
                .With<PlayerInput>()
                .And<AccumulatedMouseMovement>()
                .Build();

        public void Execute()
        {
            foreach (var inputEntity in _input)
            {
                Debug.Log($"TODO: {inputEntity}");
            }
        }
    }
}