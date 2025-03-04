using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UnitFlinchAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private float _strength = 1;
        [SerializeField] private int _vibrato = 10;
        [SerializeField] private float _randomness = 90f;

        private Tween _tween;

        public Tween Play(Entity<GameScope> unit)
        {
            _tween?.Kill();

            _tween = DOTween.Sequence(
                unit.Get<View, EntityBehaviour>()
                    .transform.DOShakePosition(_duration, _strength, _vibrato, _randomness)
            );
            return _tween;
        }
    }
}