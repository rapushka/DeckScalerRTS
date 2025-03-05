using Entitas;

namespace DeckScaler
{
    public sealed class TestSpawnUnitSystem : IInitializeSystem
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        private static IUnitFactory UnitFactory => ServiceLocator.Resolve<IUnitFactory>();

        public void Initialize()
        {
            UnitFactory.CreateOnPlayerSide(Configs.TestUnitID, new(-2f, -2f));
            UnitFactory.CreateOnPlayerSide(Configs.TestUnitID, new(2f, -2f));

            UnitFactory.CreateOnEnemySide(Configs.TestEnemyID, new(0f, 2f));
            UnitFactory.CreateOnEnemySide(Configs.TestEnemyID, new(3f, 2f));
            UnitFactory.CreateOnEnemySide(Configs.TestEnemyID, new(6f, 2f));
            UnitFactory.CreateOnEnemySide(Configs.TestEnemyID, new(6f, 5f));
        }
    }
}