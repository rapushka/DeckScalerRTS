using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class ApplyDealDamageAffects : IExecuteSystem
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
                var sender = affect.Get<AffectSender, EntityID>().GetEntity();
                var target = affect.Get<AffectTarget, EntityID>().GetEntity();

                Debug.Log($"TODO: {sender} deals damage to {target}");
            }
        }
    }
}