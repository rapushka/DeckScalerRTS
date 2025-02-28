using Entitas;

namespace DeckScaler
{
    public sealed class TestSpawnUnitSystem : IInitializeSystem
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        private static IUnitFactory UnitFactory => ServiceLocator.Resolve<IUnitFactory>();

        public void Initialize()
        {
            var id = Configs.TestUnitID;
            UnitFactory.Create(id);
        }
    }
}