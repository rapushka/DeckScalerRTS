using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class ApplyHealAffectsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _affects
            = GroupBuilder<GameScope>
                .With<Affect>()
                .And<HealAffect>()
                .And<AffectTarget>()
                .And<AffectValue>()
                .Build();

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var target = affect.Get<AffectTarget, EntityID>().GetEntity();

                if (!target.TryGet<Health, float>(out var health))
                    continue;

                var affectValue = affect.Get<AffectValue, float>();
                health += affectValue;

                target
                    .Set<Health, float>(health)
                    ;
            }
        }
    }
}