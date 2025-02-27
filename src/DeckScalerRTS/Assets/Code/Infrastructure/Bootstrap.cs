using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;

        private void Awake()
        {
            ServiceLocator.Register<IGameConfig>(_gameConfig);

            Contexts.Instance.InitializeScope<Game>();

            new GameObject(nameof(GameplayFeatureAdapter))
                .AddComponent<GameplayFeatureAdapter>();
        }
    }

    public class GameplayFeatureAdapter : FeatureAdapterBase<GameplayFeature> { }
}