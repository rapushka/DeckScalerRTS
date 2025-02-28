using DeckScaler.Scope;
using Entitas.Generic;

namespace DeckScaler
{
    public interface IUnitFactory : IService
    {
        Entity<Game> Create(UnitIDRef id);
    }

    public class UnitFactory : IUnitFactory
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        private static IEntityBehaviourFactory EntityBehaviourFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        public Entity<Game> Create(UnitIDRef id)
        {
            var unitConfig = Configs.Units.GetConfig(id);
            var entity = EntityBehaviourFactory.CreateUnitView().Entity;

            entity
                .Add<UnitID, string>(id)
                .Get<SpriteView>().Value.sprite = unitConfig.Head;

            return entity;
        }
    }
}