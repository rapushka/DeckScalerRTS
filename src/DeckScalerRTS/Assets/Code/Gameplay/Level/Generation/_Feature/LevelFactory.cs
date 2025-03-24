using System.Collections.Generic;
using Entitas.Generic;

namespace DeckScaler
{
    public interface ILevelFactory : IService
    {
        Entity<GameScope> Create(LevelData data);
    }

    public class LevelFactory : ILevelFactory
    {
        private static IUnitFactory UnitFactory => ServiceLocator.Resolve<IUnitFactory>();
        private static ITentFactory TentFactory => ServiceLocator.Resolve<ITentFactory>();
        private static IShopFactory ShopFactory => ServiceLocator.Resolve<IShopFactory>();
        private static IItemFactory ItemFactory => ServiceLocator.Resolve<IItemFactory>();

        public Entity<GameScope> Create(LevelData data)
        {
            var levelEntity = CreateEntity.Empty()
                .Add<DebugName, string>("Level");
            var levelID = levelEntity.ID();

            var tents = SpawnTents(data, levelID);
            SpawnUnits(data, tents);
            SpawnShops(data, levelID);
            SpawnItems(data, levelID);

            return levelEntity;
        }

        private Dictionary<int, EntityID> SpawnTents(LevelData data, EntityID levelID)
        {
            var tents = new Dictionary<int, EntityID>();

            foreach (var setup in data.TentSpawns)
            {
                var tentID = TentFactory.Create(setup.SpawnPoint.position)
                    .Add<ChildOf, EntityID>(levelID)
                    .ID();

                tents.Add(setup.TentIndex, tentID);
            }

            return tents;
        }

        private void SpawnUnits(LevelData data, Dictionary<int, EntityID> tents)
        {
            foreach (var setup in data.UnitSpawns)
            {
                var unitID = setup.UnitID;
                var spawnPosition = setup.SpawnPoint.position;

                if (setup.Side is Side.Player)
                {
                    UnitFactory.CreateOnPlayerSide(unitID, spawnPosition);
                }
                else if (setup.Side is Side.Enemy)
                {
                    var tentID = tents[setup.TentIndex];
                    UnitFactory.CreateOnEnemySide(unitID, spawnPosition, tentID);
                }
                else
                    throw new("Side is Unknown!");
            }
        }

        private void SpawnShops(LevelData data, EntityID levelID)
        {
            foreach (var setup in data.ShopSpawns)
            {
                var spawnPosition = setup.SpawnPoint.position;
                ShopFactory.Create(spawnPosition)
                    .Add<ChildOf, EntityID>(levelID);
            }
        }

        private void SpawnItems(LevelData data, EntityID levelID)
        {
            foreach (var setup in data.ItemSpawns)
            {
                ItemFactory.CreateOnGround(setup)
                    .Add<ChildOf, EntityID>(levelID);
            }
        }
    }
}