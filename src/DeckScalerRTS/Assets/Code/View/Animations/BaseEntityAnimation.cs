using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public abstract class BaseEntityAnimation : MonoBehaviour, IEntityAnimator
    {
        public abstract Tween Play(Entity<GameScope> entity);
    }
}