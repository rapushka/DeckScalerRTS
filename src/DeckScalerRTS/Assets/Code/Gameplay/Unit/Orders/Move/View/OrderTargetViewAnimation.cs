using DG.Tweening;
using UnityEngine;

namespace DeckScaler
{
    public class OrderTargetViewAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Color _positionOrderColor;
        [SerializeField] private Color _attackUnitOrderColor;

        [Header("Animation")]
        [SerializeField] private float _appearDuration;
        [SerializeField] private float _fromScale;
        [SerializeField] private float _toScale;

        [Space]
        [SerializeField] private float _pause;

        [Space]
        [SerializeField] private Vector3 _disappearOffset = new(0f, 0.25f, 0f);
        [SerializeField] private float _disappearDuration;

        private Tween _sequence;

        public float WholeAnimationDuration => _appearDuration + _pause + _disappearDuration;

        public void Play(bool isAttack)
        {
            _sprite.color = isAttack ? _attackUnitOrderColor : _positionOrderColor;

            _sprite.SetAlpha(0f);
            _target.localScale = Vector3.one * _fromScale;
            _target.SetPosition(z: -5);

            _sequence?.Kill();
            _sequence = DOTween.Sequence()
                    .Append(_target.DOScale(_toScale, _appearDuration))
                    .Join(_sprite.DOFade(1f, _appearDuration * 0.25f))
                    .AppendInterval(_pause)
                    .Append(_sprite.DOFade(0f, _disappearDuration))
                    .Join(_target.DOPunchPosition(_disappearOffset, _disappearDuration * 2f))
                    .SetEase(Ease.InOutSine)
                ;
        }
    }
}