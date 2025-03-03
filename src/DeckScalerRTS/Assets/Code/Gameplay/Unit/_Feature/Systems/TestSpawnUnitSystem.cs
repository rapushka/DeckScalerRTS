using Entitas;

namespace DeckScaler
{
    public sealed class TestSpawnUnitSystem : IInitializeSystem
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        private static IUnitFactory UnitFactory => ServiceLocator.Resolve<IUnitFactory>();

        public void Initialize()
        {
            UnitFactory.Create(Configs.TestUnitID, new(-2f, -2f));
            UnitFactory.Create(Configs.TestUnitID, new(2f, -2f));
        }
    }
}