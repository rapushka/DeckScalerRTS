using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UnitAttackAnimation : MonoBehaviour
    {
        [SerializeField] private float _punchDistance;
        [SerializeField] private float _attackingScale;
        [SerializeField] private float _duration;
        [SerializeField] private float _returnDuration;

        private Tween _tween;
        private Vector3 _initialScale;

        public Tween Play(Entity<GameScope> attacker, Entity<GameScope> target)
        {
            var attackerWorldPosition = attacker.Get<WorldPosition, Vector2>();
            var targetWorldPosition = target.Get<WorldPosition, Vector2>();

            _tween?.Kill();

            _initialScale = transform.localScale;

            var punchDirection = targetWorldPosition - attackerWorldPosition;
            var punchPosition = punchDirection * _punchDistance;

            _tween = DOTween.Sequence()
                    // prepare
                    .Append(transform.DOScale(_initialScale * _attackingScale, _duration))

                    // punch
                    .Append(transform.DOPunchPosition(punchPosition, _duration, vibrato: 0))

                    // recovery
                    .Append(transform.DOScale(_initialScale, _returnDuration))
                    .OnKill(ResetTransform)
                ;

            return _tween;
        }

        private void ResetTransform()
        {
            transform.localScale = _initialScale;
        }
    }
}