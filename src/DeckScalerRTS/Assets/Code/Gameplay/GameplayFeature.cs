using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
        {
            // # Initialize
            Add(new InitializeInputSystem());
            Add(new TestSpawnUnitSystem());

            // # Update
            Add(new EmitMousePositionSystem());
            Add(new OnDragCameraStartedSystem());
            Add(new ReadClicksOnEntitySystem());
            Add(new DragCameraSystem());
            Add(new LogClickedUnitSystem());

            // # Boilerplate
            var contexts = Contexts.Instance;
            Add(new SelfEventSystem<GameScope, HeadSprite>(contexts));
            Add(new RemoveComponentsSystem<GameScope, Clicked>(contexts));
        }
    }
}