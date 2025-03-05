using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class EntityAnimatorComponentBehaviour : ComponentBehaviourBase<GameScope>
    {
        [SerializeField] private BaseEntityAnimation _animation;

        public override void Add(ref Entity<GameScope> entity)
            => entity.Add<Animator, IEntityAnimator>(_animation);

        public override void Remove(ref Entity<GameScope> entity)
            => entity.Remove<Animator>();
    }
}