using Entitas.Generic;

namespace DeckScaler
{
    public interface IDebugService : IService
    {
        void Initialize();
    }

    public class DebugService : IDebugService, IUpdatable
    {
        private readonly DebugSettings _settings;
        private readonly EntityParenthoodDebugger _entityParenthoodParenthood;

        public DebugService(DebugSettings settings)
        {
            _settings = settings;
            _entityParenthoodParenthood = new();
        }

        public void Initialize()
        {
            SetupEntityFormatters();

            if (_settings.EnableEntityParenthoodDebugger)
                _entityParenthoodParenthood.Initialize();
        }

        void IUpdatable.OnUpdate(float deltaTime)
        {
            _entityParenthoodParenthood.OnUpdate(deltaTime);
        }

        private static void SetupEntityFormatters()
        {
            Entity<GameScope>.Formatter = new GameEntityFormatter();
            Entity<UiScope>.Formatter = new UiEntityFormatter();
        }
    }
}