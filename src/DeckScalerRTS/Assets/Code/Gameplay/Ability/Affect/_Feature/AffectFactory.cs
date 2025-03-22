using Entitas.Generic;

namespace DeckScaler
{
    public interface IAffectFactory : IService
    {
        Entity<GameScope> Create(AffectConfig ability, Entity<GameScope> sender, Entity<GameScope> target);
        Entity<GameScope> Create(AffectConfig ability, Entity<GameScope> sender);
    }

    public class AffectFactory : IAffectFactory
    {
        public Entity<GameScope> Create(AffectConfig ability, Entity<GameScope> sender, Entity<GameScope> target)
            => Create(ability, sender)
                .Add<AffectTarget, EntityID>(target.ID());

        public Entity<GameScope> Create(AffectConfig ability, Entity<GameScope> sender)
            => CreateEntity.OneFrame()
                .Add<DebugName, string>("ability")
                .Add<Affect>()
                .Add<AffectValue, float>(ability.Value)
                .Add<AffectSender, EntityID>(sender.ID())
                .Is<OnPlayerSide>(sender.Is<OnPlayerSide>())
                .Is<OnEnemySide>(sender.Is<OnEnemySide>())
                .Is<DealDamageAffect>(ability.Type is AffectType.DealDamage)
                .Is<GainMoneyAffect>(ability.Type is AffectType.GainMoney);
    }
}