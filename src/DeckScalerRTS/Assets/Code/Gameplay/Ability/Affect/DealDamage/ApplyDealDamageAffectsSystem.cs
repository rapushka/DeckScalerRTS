using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class ApplyDealDamageAffectsSystem : IExecuteSystem
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

                Debug.Log($"TODO: {senderID} deals damage to {targetID}");
            }
        }
    }
}