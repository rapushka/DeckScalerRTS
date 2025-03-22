using Entitas.Generic;

namespace DeckScaler
{
    public interface IAbilityFactory : IService
    {
        public Entity<GameScope> Create(Entity<GameScope> owner, AbilityConfig config);
    }

    public class AbilityFactory : IAbilityFactory
    {
        public Entity<GameScope> Create(Entity<GameScope> owner, AbilityConfig config)
        {
            var ownerID = owner.ID();

            var entity = CreateEntity.Empty()
                    .Add<DebugName, string>("ability")
                    .Add<AbilityOf, EntityID>(ownerID)
                    .Add<ChildOf, EntityID>(ownerID)
                    .Add<AbilityAffectConfig, AffectConfig>(config.Affect)
                    .Add<Range, float>(config.Range)
                    .Add<BaseCooldown, float>(config.Cooldown)
                    .Add<CooldownTimer, Timer>(new(0f))
                ;

            if (config.TriggerType is AbilityTriggerType.HasOpponent)
                entity.Add<CastOnOpponent>();

            if (config.TriggerType is AbilityTriggerType.OnKilledUnit)
                entity.Add<CastWhenKilledUnit>();

            return entity;
        }
    }
}