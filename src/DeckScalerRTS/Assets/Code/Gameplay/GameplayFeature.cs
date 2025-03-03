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
            Add(new EmitMouseInputSystem());
            Add(new ReadClicksOnEntitySystem());

            // # Boilerplate
            var contexts = Contexts.Instance;
            Add(new SelfEventSystem<GameScope, HeadSprite>(contexts));
        }
    }
}