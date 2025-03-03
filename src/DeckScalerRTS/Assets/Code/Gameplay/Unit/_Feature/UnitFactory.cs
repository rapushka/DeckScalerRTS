using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IUnitFactory : IService
    {
        Entity<GameScope> Create(UnitIDRef id, Vector2 position);
    }

    public class UnitFactory : IUnitFactory
    {
        private static IGameConfig Configs => ServiceLocator.Resolve<IGameConfig>();

        private static IEntityBehaviourFactory EntityBehaviourFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        public Entity<GameScope> Create(UnitIDRef id, Vector2 position)
        {
            var unitConfig = Configs.Units.GetConfig(id);

            return EntityBehaviourFactory.CreateUnitView(position).Entity
                    .Add<UnitID, string>(id)
                    .Set<HeadSprite, Sprite>(unitConfig.Head)
                    .Is<Clickable>(true)
                ;
        }
    }
}