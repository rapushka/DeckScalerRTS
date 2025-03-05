using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UnitAnimatorComponentBehaviour : ComponentBehaviourBase<GameScope>
    {
        [SerializeField] private UnitAnimator _animator;

        public override void Add(ref Entity<GameScope> entity)
            => entity.Add<Animator, IEntityAnimator>(_animator);

        public override void Remove(ref Entity<GameScope> entity)
            => entity.Remove<Animator>();
    }
}