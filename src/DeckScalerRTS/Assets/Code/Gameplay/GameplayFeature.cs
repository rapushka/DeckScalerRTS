using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
        {
            Add(new TestSpawnUnitSystem());

            var contexts = Contexts.Instance;
            Add(new SelfEventSystem<Game, HeadSprite>(contexts));
        }
    }
}