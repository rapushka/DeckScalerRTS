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
            ServiceLocator.Register<IAbilityFactory>(new AbilityFactory());
            ServiceLocator.Register<IAffectFactory>(new AffectFactory());
            ServiceLocator.Register<ITentFactory>(new TentFactory());

            // Scopes
            Contexts.Instance.InitializeScope<GameScope>();
            Contexts.Instance.InitializeScope<InputScope>();

            // Indexes
            Contexts.Instance.Get<GameScope>().GetPrimaryIndex<ID, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<AbilityOf, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<ChildOf, EntityID>().Initialize();
            Contexts.Instance.Get<GameScope>().GetIndex<OnTent, EntityID>().Initialize();

#if UNITY_EDITOR
            Entity<GameScope>.Formatter = new GameEntityFormatter();
#endif

            new GameObject(nameof(GameplayFeatureAdapter))
                .AddComponent<GameplayFeatureAdapter>();
        }
    }

    public class GameplayFeatureAdapter : FeatureAdapterBase<GameplayFeature> { }
}