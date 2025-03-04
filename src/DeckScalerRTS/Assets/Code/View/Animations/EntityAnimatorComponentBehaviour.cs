using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class EntityAnimatorComponentBehaviour : ComponentBehaviourBase<GameScope>
    {
        [SerializeField] private BaseEntityAnimation _animation;

        public override void Add(ref Entity<GameScope> entity)
        {
            entity.Add<Animatior, IEntityAnimation>(_animation);
            _animation.Register(entity);
        }

        public override void Remove(ref Entity<GameScope> entity)
        {
            entity.Remove<Animatior>();
            _animation.Unregister();
        }
    }
}