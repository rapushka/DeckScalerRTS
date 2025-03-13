using Entitas;
using UnityEngine;

namespace DeckScaler
{
    public sealed class InitializeInputSystem : IInitializeSystem
    {
        public void Initialize()
        {
            CreateInputEntity.Empty()
                .Add<PlayerInput>()
                .Add<MouseWorldPosition, Vector2>(Vector2.zero)
                ;
        }
    }
}