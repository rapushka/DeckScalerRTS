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

        public Entity<GameScope> Create(LevelData data)
        {
            var levelEntity = CreateEntity.Empty()
                .Add<DebugName, string>("Level");
            var levelID = levelEntity.ID();

            var tents = new Dictionary<int, EntityID>();

            foreach (var setup in data.TentSpawns)
            {
                var tentID = TentFactory.Create(setup.SpawnPoint.position)
                    .Add<ChildOf, EntityID>(levelID)
                    .ID();

                tents.Add(setup.TentIndex, tentID);
            }

            foreach (var setup in data.UnitSpawns)
            {
                var unitID = setup.UnitID;
                var spawnPosition = setup.SpawnPoint.position;

                if (setup.Side is Side.Player)
                {
                    UnitFactory.CreateOnPlayerSide(unitID, spawnPosition)
                        .Add<ChildOf, EntityID>(levelID);
                }
                else if (setup.Side is Side.Enemy)
                {
                    var tentID = tents[setup.TentIndex];
                    UnitFactory.CreateOnEnemySide(unitID, spawnPosition, tentID);
                }
                else
                    throw new("Side is Unknown!");
            }

            return levelEntity;
        }
    }
}