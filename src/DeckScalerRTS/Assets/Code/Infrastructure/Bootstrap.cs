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

        [NaughtyAttributes.BoxGroup("Debug")]
        [SerializeField] private DebugSettings _debugSettings;

        private InputService _inputService;
        private DebugService _debugger;

        [NaughtyAttributes.Button]
        public void CollectSpawnMarkers()
        {
            _levelGenerator.Tents = FindObjectsByType<TentSpawnMarker>(FindObjectsSortMode.None);
            _levelGenerator.Units = FindObjectsByType<UnitSpawnMarker>(FindObjectsSortMode.None);
            _levelGenerator.Shops = FindObjectsByType<ShopSpawnMarker>(FindObjectsSortMode.None);
            _levelGenerator.Items = FindObjectsByType<ItemSpawnMarker>(FindObjectsSortMode.None);
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
            ServiceLocator.Register<IViewFactory>(new ViewFactory());
            ServiceLocator.Register<IUnitFactory>(new UnitFactory());
            ServiceLocator.Register<IAbilityFactory>(new AbilityFactory());
            ServiceLocator.Register<IAffectFactory>(new AffectFactory());
            ServiceLocator.Register<ITentFactory>(new TentFactory());
            ServiceLocator.Register<IUiFactory>(new UiFactory());
            ServiceLocator.Register<ILevelFactory>(new LevelFactory());
            ServiceLocator.Register<IShopFactory>(new ShopFactory());
            ServiceLocator.Register<IItemFactory>(new ItemFactory());
            ServiceLocator.Register<IInventoryFactory>(new InventoryFactory());
            ServiceLocator.Register<IInventoryUIFactory>(new InventoryUIFactory());

            // Debug
#if UNITY_EDITOR
            _debugger = new(_debugSettings);
            ServiceLocator.Register<IDebugService>(_debugger);
#else
            ServiceLocator.Register<IDebugService>(new MockDebugService());
#endif
        }

        private void Update()
        {
            var deltaTime = ServiceLocator.Resolve<ITimeService>().Delta;

            ((IUpdatable)_inputService).OnUpdate(deltaTime);
            (_debugger as IUpdatable)?.OnUpdate(deltaTime);
        }
    }
}