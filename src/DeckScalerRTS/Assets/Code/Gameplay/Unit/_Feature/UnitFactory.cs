using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IUnitFactory : IService
    {
        Entity<GameScope> CreateOnPlayerSide(UnitIDRef id, Vector2 position);
        Entity<GameScope> CreateOnEnemySide(UnitIDRef id, Vector2 position);
    }

    public class UnitFactory : IUnitFactory
    {
        private static UnitsConfig UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units;

        private static IEntityBehaviourFactory EntityBehaviourFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        public Entity<GameScope> CreateOnPlayerSide(UnitIDRef id, Vector2 position)
            => CreateUnit(id, position)
                .Add<OnSide, Side>(Side.Player)
                .Add<OnPlayerSide>();

        public Entity<GameScope> CreateOnEnemySide(UnitIDRef id, Vector2 position)
            => CreateUnit(id, position)
                .Add<OnSide, Side>(Side.Enemy)
                .Add<OnEnemySide>();

        private static Entity<GameScope> CreateUnit(UnitIDRef id, Vector2 position)
        {
            var unitConfig = UnitsConfig.GetConfig(id);

            return EntityBehaviourFactory.CreateUnitView(position).Entity
                    .Add<UnitID, string>(id)
                    .Set<HeadSprite, Sprite>(unitConfig.Head)
                    .Is<Clickable>(true)
                    .Add<WorldPosition, Vector2>(position)
                    .Add<MovementSpeed, float>(unitConfig.MovementSpeed)
                    .Add<AttackTriggerRadius, float>(UnitsConfig.Common.AttackTriggerRadius)
                    .Add<AttackRange, float>(unitConfig.AttackRange)
                    .Add<AttackCooldown, float>(unitConfig.AttackCooldown)
                    .Add<InAutoAttackState>()
                ;
        }
    }
}