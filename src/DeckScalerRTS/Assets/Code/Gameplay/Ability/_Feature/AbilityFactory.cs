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
            var entity = CreateEntity.Empty()
                    .Add<DebugName, string>("ability")
                    .Add<AbilityOf, EntityID>(owner.ID())
                    .Add<AbilityValue, float>(config.BaseValue)
                    .Add<Range, float>(config.Range)
                    .Add<BaseCooldown, float>(config.Cooldown)
                    .Add<CooldownTimer, Timer>(new(0f))
                ;

            if (config.TargetType is AbilityUseTargetType.OnOpponent)
                entity.Add<UseOnOpponent>();

            return entity;
        }
    }
}