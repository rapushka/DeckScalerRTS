using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Contexts.Instance.InitializeScope<Game>();

            new GameObject(nameof(GameplayFeatureAdapter))
                .AddComponent<GameplayFeatureAdapter>();
        }
    }

    public class GameplayFeatureAdapter : FeatureAdapterBase<GameplayFeature> { }
}