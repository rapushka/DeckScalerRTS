using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IEntityAnimation
    {
        Tween Play(Entity<GameScope> entity);
    }

    public abstract class BaseEntityAnimation : MonoBehaviour, IEntityAnimation
    {
        protected Entity<GameScope> Entity { get; private set; }

        public void Register(Entity<GameScope> entity)
        {
            entity.Retain(this);
            Entity = entity;
        }

        public abstract Tween Play(Entity<GameScope> entity);

        public void Unregister()
        {
            Entity.Release(this);
            Entity = null;
        }
    }
}