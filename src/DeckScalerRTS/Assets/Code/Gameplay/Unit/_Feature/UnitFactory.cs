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

        private static IViewFactory      ViewFactory      => ServiceLocator.Resolve<IViewFactory>();
        private static IAbilityFactory   AbilityFactory   => ServiceLocator.Resolve<IAbilityFactory>();
        private static IInventoryFactory InventoryFactory => ServiceLocator.Resolve<IInventoryFactory>();

        public Entity<GameScope> CreateOnPlayerSide(UnitIDRef id, Vector2 position)
            => UnitUtils.IntoFella(CreateUnit(id, position));

        public Entity<GameScope> CreateOnEnemySide(UnitIDRef id, Vector2 position, EntityID tent)
            => UnitUtils.IntoEnemy(CreateUnit(id, position), tent);

        public Entity<GameScope> CreateInShop(UnitIDRef id, Vector2 position)
            => CreateUnit(id, position);

        private Entity<GameScope> CreateUnit(UnitIDRef id, Vector2 position)
        {
            var config = UnitsConfig.GetConfig(id);

            var baseStats = Stats.Empty()
                .With(StatID.MovementSpeed, config.MovementSpeed);

            var unit = ViewFactory.CreateInWorld(UnitsConfig.UnitViewPrefab, position).Entity;
            unit
                .Add<DebugName, string>($"unit {TrimUniID(id.Value)}")
                .Add<UnitID, UnitIDRef>(id)
                .Set<HeadSprite, Sprite>(config.Head)
                .Is<Clickable>(true)
                .Add<WorldPosition, Vector2>(position)
                .Add<MovementSpeed, float>(config.MovementSpeed)
                .Add<AgroTriggerRadius, float>(UnitsConfig.Common.AttackTriggerRadius)
                .Add<InAutoAttackState>()
                .Add<MaxHealth, float>(config.MaxHealth)
                .Add<Health, float>(config.MaxHealth)
                .Add<Price, int>(config.Price)
                .Is<Lead>(config.IsLead)
                .Add<EffectiveRange, float>(config.Range)
                .Is<HasInventory>(config.InventorySlots > 0)
                .Is<HasAnyFreeInventorySlot>(config.InventorySlots > 0)
                .Add<Hoverable>()
                .Add<BaseStats, Stats>(baseStats)
                .Add<StatModifiers, StatMods>(StatMods.Empty())
                ;

            CreateAbilities(unit, config);
            CreateInventorySlots(unit, config);

            return unit;
        }

        private static void CreateAbilities(Entity<GameScope> unit, UnitConfig unitConfig)
        {
            foreach (var abilityConfig in unitConfig.Abilities)
                AbilityFactory.Create(unit, abilityConfig);
        }

        private void CreateInventorySlots(Entity<GameScope> unit, UnitConfig unitConfig)
        {
            for (var i = 0; i < unitConfig.InventorySlots; i++)
            {
                InventoryFactory.CreateSlot(unit.ID(), i);
            }
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