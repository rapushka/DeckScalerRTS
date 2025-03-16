using Entitas;

namespace DeckScaler
{
    public sealed class GenerateLevelSystem : IInitializeSystem
    {
        private static ILevelGenerator LevelGenerator => ServiceLocator.Resolve<ILevelGenerator>();

        private static ILevelFactory Factory => ServiceLocator.Resolve<ILevelFactory>();

        public void Initialize()
        {
            Factory.Create(LevelGenerator.GenerateLevel());
        }
    }
}