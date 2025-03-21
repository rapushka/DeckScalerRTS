using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [UnitID]
        [SerializeField] private int _invalid;

        [SerializeField] private GameConfig _gameConfig;

        [NaughtyAttributes.BoxGroup("Cameras")]
        [SerializeField] private Camera _mainCamera;
        [NaughtyAttributes.BoxGroup("Cameras")]
        [SerializeField] private Camera _uiCamera;

        [NaughtyAttributes.BoxGroup("UI")]
        [SerializeField] private Canvas _canvas;

        [NaughtyAttributes.BoxGroup("Level")]
        [SerializeField] private TemporaryLevelGenerator _levelGenerator;

        private InputService _inputService;

        [NaughtyAttributes.Button]
        public void CollectSpawnMarkers()
        {
            _levelGenerator.Tents = FindObjectsByType<TentSpawnMarker>(FindObjectsSortMode.None);
            _levelGenerator.Units = FindObjectsByType<UnitSpawnMarker>(FindObjectsSortMode.None);
            _levelGenerator.Shops = FindObjectsByType<ShopSpawnMarker>(FindObjectsSortMode.None);
        }

        private void Awake()
        {
            RegisterServices();
            Game.Instance.Start();
        }

        private void RegisterServices()
        {
            // Services
            ServiceLocator.Register<IGameStateMachine>(new GameStateMachine());
            ServiceLocator.Register<IGameConfig>(_gameConfig);
            _inputService = new();
            ServiceLocator.Register<IInputService>(_inputService);
            ServiceLocator.Register<ICameraService>(new CameraService(_mainCamera, _uiCamera));
            ServiceLocator.Register<IIdentifiesService>(new SimplestIdentifiesService());
            ServiceLocator.Register<ITimeService>(new TimeService());
            ServiceLocator.Register<IUiService>(new UiService(_canvas));
            ServiceLocator.Register<IUiMediator>(new UiMediator());
            ServiceLocator.Register<IPagesService>(new PagesService());
            ServiceLocator.Register<ILevelGenerator>(_levelGenerator);
            ServiceLocator.Register<IRandomService>(new RandomService());

            // Factories
            ServiceLocator.Register<IEntityBehaviourFactory>(new EntityBehaviourFactory());
            ServiceLocator.Register<IUnitFactory>(new UnitFactory());
            ServiceLocator.Register<IAbilityFactory>(new AbilityFactory());
            ServiceLocator.Register<IAffectFactory>(new AffectFactory());
            ServiceLocator.Register<ITentFactory>(new TentFactory());
            ServiceLocator.Register<IUiFactory>(new UiFactory());
            ServiceLocator.Register<ILevelFactory>(new LevelFactory());
            ServiceLocator.Register<IShopFactory>(new ShopFactory());
        }

        private void Update()
        {
            var deltaTime = ServiceLocator.Resolve<ITimeService>().Delta;

            ((IUpdatable)_inputService).OnUpdate(deltaTime);
        }
    }
}