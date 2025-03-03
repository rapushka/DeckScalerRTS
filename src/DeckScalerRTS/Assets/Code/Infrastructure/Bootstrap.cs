using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private Camera _mainCamera;

        private void Awake()
        {
            ServiceLocator.Register<IGameConfig>(_gameConfig);

            // Services
            ServiceLocator.Register<IInputService>(new InputService());
            ServiceLocator.Register<ICameraService>(new CameraService(_mainCamera));
            ServiceLocator.Register<IIdentifiesService>(new SimplestIdentifiesService());
            ServiceLocator.Register<ITimeService>(new TimeService());

            // Factories
            ServiceLocator.Register<IEntityBehaviourFactory>(new EntityBehaviourFactory());
            ServiceLocator.Register<IUnitFactory>(new UnitFactory());

            Contexts.Instance.InitializeScope<GameScope>();
            Contexts.Instance.InitializeScope<InputScope>();

            Contexts.Instance.EntityIDIndex().Initialize();

            new GameObject(nameof(GameplayFeatureAdapter))
                .AddComponent<GameplayFeatureAdapter>();
        }
    }

    public class GameplayFeatureAdapter : FeatureAdapterBase<GameplayFeature> { }
}