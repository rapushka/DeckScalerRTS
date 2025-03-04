using Entitas.Generic;

namespace DeckScaler
{
    public interface IAffectFactory : IService
    {
        void Create(AffectConfig ability, Entity<GameScope> sender, Entity<GameScope> target);
    }

    public class AffectFactory : IAffectFactory
    {
        public void Create(AffectConfig ability, Entity<GameScope> sender, Entity<GameScope> target)
        {
            CreateEntity.OneFrame()
                .Add<DebugName, string>("ability")
                .Add<Affect>()
                .Add<AffectValue, float>(ability.Value)
                .Add<AffectSender, EntityID>(sender.ID())
                .Add<AffectTarget, EntityID>(target.ID())
                .Is<DealDamageAffect>(ability.Type is AffectType.DealDamage)
                ;
        }
    }
}