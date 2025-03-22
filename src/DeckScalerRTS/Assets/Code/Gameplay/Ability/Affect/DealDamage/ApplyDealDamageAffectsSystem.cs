using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ApplyDealDamageAffectsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _affects
            = GroupBuilder<GameScope>
                .With<Affect>()
                .And<DealDamageAffect>()
                .And<AffectTarget>()
                .And<AffectValue>()
                .Build();

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var sender = affect.Get<AffectSender, EntityID>();
                var target = affect.Get<AffectTarget, EntityID>().GetEntity();

                if (!target.TryGet<Health, float>(out var health))
                    continue;

                var affectValue = affect.Get<AffectValue, float>();
                health = (health - affectValue).Clamp(min: 0);

                target
                    .Set<Health, float>(health)
                    .Set<LastHitFrom, EntityID>(sender)
                    ;
            }
        }
    }
}