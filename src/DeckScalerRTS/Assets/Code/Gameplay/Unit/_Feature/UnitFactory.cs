using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

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

            return EntityBehaviourFactory.CreateUnitView().Entity
                    .Add<UnitID, string>(id)
                    .Set<HeadSprite, Sprite>(unitConfig.Head)
                ;
        }
    }
}