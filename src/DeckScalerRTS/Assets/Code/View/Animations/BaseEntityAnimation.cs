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
        public abstract Tween Play(Entity<GameScope> entity);
    }
}