using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class OrderTargetViewAnimation : BaseEntityAnimation
    {
        [SerializeField] private Transform _target;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Color _positionOrderColor;
        [SerializeField] private Color _attackUnitOrderColor;

        [Header("Animation")]
        [SerializeField] private float _appearDuration;
        [SerializeField] private float _fadeInDuration;
        [SerializeField] private float _fromScale;
        [SerializeField] private float _toScale;

        [Space]
        [SerializeField] private float _pause;

        [Space]
        [SerializeField] private Vector3 _disappearOffset = new(0f, 0.25f, 0f);
        [SerializeField] private float _disappearDuration;

        private Tween _tween;

        public override Tween Play(Entity<GameScope> entity)
        {
            var isAttack = entity.Is<ProcessedAsAttackOrder>();

            _sprite.color = isAttack ? _attackUnitOrderColor : _positionOrderColor;

            _sprite.SetAlpha(0f);
            _target.localScale = Vector3.one * _fromScale;
            _target.SetPosition(z: -5);

            _tween?.Kill();
            _tween = DOTween.Sequence()
                    .Append(_target.DOScale(_toScale, _appearDuration))
                    .Join(_sprite.DOFade(1f, _fadeInDuration))
                    .AppendInterval(_pause)
                    .Append(_sprite.DOFade(0f, _disappearDuration))
                    .Join(_target.DOLocalMove(_target.position + _disappearOffset, _disappearDuration * 2f))
                    .SetEase(Ease.InOutSine)
                ;

            return _tween;
        }
    }
}