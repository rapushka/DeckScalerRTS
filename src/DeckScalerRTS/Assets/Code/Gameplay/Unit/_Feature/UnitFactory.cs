using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IUnitFactory : IService
    {
        Entity<GameScope> CreateOnPlayerSide(UnitIDRef id, Vector2 position);
        Entity<GameScope> CreateOnEnemySide(UnitIDRef id, Vector2 position, EntityID tent);

        Entity<GameScope> CreateInShop(UnitIDRef id, Vector2 position);
    }

    public class UnitFactory : IUnitFactory
    {
        private static UnitsConfig UnitsConfig => ServiceLocator.Resolve<IGameConfig>().Units;

        private static IEntityBehaviourFactory EntityBehaviourFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        private static IAbilityFactory AbilityFactory => ServiceLocator.Resolve<IAbilityFactory>();

        public Entity<GameScope> CreateOnPlayerSide(UnitIDRef id, Vector2 position)
            => UnitUtils.Hire(CreateUnit(id, position));

        public Entity<GameScope> CreateOnEnemySide(UnitIDRef id, Vector2 position, EntityID tent)
            => CreateUnit(id, position)
                .Add<OnSide, Side>(Side.Enemy)
                .Add<OnEnemySide>()
                .Add<OnTent, EntityID>(tent)
                .Add<ChildOf, EntityID>(tent);

        public Entity<GameScope> CreateInShop(UnitIDRef id, Vector2 position)
            => CreateUnit(id, position);

        private Entity<GameScope> CreateUnit(UnitIDRef id, Vector2 position)
        {
            var unitConfig = UnitsConfig.GetConfig(id);

            var unit = EntityBehaviourFactory.CreateUnitView(position).Entity;
            unit
                .Add<DebugName, string>($"unit {TrimUniID(id.Value)}")
                .Add<UnitID, UnitIDRef>(id)
                .Set<HeadSprite, Sprite>(unitConfig.Head)
                .Is<Clickable>(true)
                .Add<WorldPosition, Vector2>(position)
                .Add<MovementSpeed, float>(unitConfig.MovementSpeed)
                .Add<AgroTriggerRadius, float>(UnitsConfig.Common.AttackTriggerRadius)
                .Add<InAutoAttackState>()
                .Add<MaxHealth, float>(unitConfig.MaxHealth)
                .Add<Health, float>(unitConfig.MaxHealth)
                .Add<Price, int>(unitConfig.Price)
                ;

            foreach (var abilityConfig in unitConfig.Abilities)
                AbilityFactory.Create(unit, abilityConfig);

            unit.Add<EffectiveRange, float>(unitConfig.Range);

            if (unitConfig.IsLead)
                unit.Add<Lead>();

            return unit;
        }

        private string TrimUniID(string source)
        {
#if UNITY_EDITOR
            source = source.Remove(Constants.TableID.Units);
#endif

            return source;
        }
    }
}