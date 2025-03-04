using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class PlayDealDamageAnimationsSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _affects
            = GroupBuilder<GameScope>
                .With<Affect>()
                .And<DealDamageAffect>()
                .And<AffectTarget>()
                .Build();

        public void Execute()
        {
            foreach (var affect in _affects)
            {
                var senderID = affect.Get<AffectSender, EntityID>();
                var targetID = affect.Get<AffectTarget, EntityID>();

                senderID.GetEntity().GetOrDefault<Animatior, IEntityAnimation>()?.Play(affect);
                targetID.GetEntity().GetOrDefault<Animatior, IEntityAnimation>()?.Play(affect);
            }
        }
    }
}