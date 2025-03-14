using UnityEngine;

namespace DeckScaler
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameConfig _gameConfig;

        [NaughtyAttributes.BoxGroup("Cameras")]
        [SerializeField] private Camera _mainCamera;
        [NaughtyAttributes.BoxGroup("Cameras")]
        [SerializeField] private Camera _uiCamera;

        [NaughtyAttributes.BoxGroup("UI")]
        [SerializeField] private Canvas _canvas;

        private InputService _inputService;

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

            // Factories
            ServiceLocator.Register<IEntityBehaviourFactory>(new EntityBehaviourFactory());
            ServiceLocator.Register<IUnitFactory>(new UnitFactory());
            ServiceLocator.Register<IAbilityFactory>(new AbilityFactory());
            ServiceLocator.Register<IAffectFactory>(new AffectFactory());
            ServiceLocator.Register<ITentFactory>(new TentFactory());
            ServiceLocator.Register<IUiFactory>(new UiFactory());
        }

        private void Update()
        {
            var deltaTime = ServiceLocator.Resolve<ITimeService>().Delta;

            ((IUpdatable)_inputService).OnUpdate(deltaTime);
        }
    }
}