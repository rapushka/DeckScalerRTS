using Entitas;
using UnityEngine;

namespace DeckScaler
{
    public sealed class GameplayFeature : Feature
    {
        public GameplayFeature()
        {
            Add(new TestGreetSystem());
        }
    }

    public class TestGreetSystem : IInitializeSystem
    {
        public void Initialize()
        {
            Debug.Log("Hello!");
        }
    }
}