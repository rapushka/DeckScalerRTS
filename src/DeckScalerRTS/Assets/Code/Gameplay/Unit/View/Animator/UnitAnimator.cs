using System;
using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UnitAnimator : BaseEntityAnimation
    {
        [SerializeField] private UnitAttackAnimation _attackAnimation;
        [SerializeField] private UnitFlinchAnimation _flinchAnimation;

        private Entity<GameScope> Unit => Entity;

        public override Tween Play(Entity<GameScope> affect) // TODO: this is shi.......
        {
            if (!affect.Is<DealDamageAffect>())
                throw new NotImplementedException("There's no animations for other affects yet (and there's no other affects at all tbf)");

            var senderID = affect.Get<AffectSender, EntityID>();
            var targetID = affect.Get<AffectTarget, EntityID>();

            var isSender = Unit.ID() == senderID;
            var isTarget = Unit.ID() == targetID;

            if (isSender)
                return _attackAnimation.Play(senderID.GetEntity(), targetID.GetEntity());

            if (isTarget)
                return _flinchAnimation.Play(targetID.GetEntity());

            throw new InvalidOperationException();
        }
    }
}