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
            ServiceLocator.Register<IEntityBehaviourFactory>(new EntityBehaviourFactory());
            ServiceLocator.Register<IUnitFactory>(new UnitFactory());

            Contexts.Instance.InitializeScope<Game>();

            new GameObject(nameof(GameplayFeatureAdapter))
                .AddComponent<GameplayFeatureAdapter>();
        }
    }

    public class GameplayFeatureAdapter : FeatureAdapterBase<GameplayFeature> { }
}