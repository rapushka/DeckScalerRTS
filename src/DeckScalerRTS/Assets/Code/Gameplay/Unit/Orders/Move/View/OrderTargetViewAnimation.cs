using DG.Tweening;
using UnityEngine;

namespace DeckScaler
{
    public class OrderTargetViewAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private SpriteRenderer _sprite;

        [Header("Animation")]
        [SerializeField] private float _fromScale;
        [SerializeField] private float _toScale;
        [SerializeField] private float _appearDuration;
        [SerializeField] private float _pause;
        [SerializeField] private float _disappearDuration;

        private Tween _sequence;

        public float WholeAnimationDuration => _appearDuration + _pause + _disappearDuration;

        public void Play()
        {
            _sprite.SetAlpha(0f);
            _target.localScale = Vector3.one * _fromScale;

            _sequence?.Kill();
            _sequence = DOTween.Sequence()
                    .Append(_target.DOScale(_toScale, _appearDuration))
                    .Join(_sprite.DOFade(1f, _appearDuration))
                    .AppendInterval(_pause)
                    .Append(_sprite.DOFade(0f, _disappearDuration))
                    .Join(_target.DOPunchPosition(Vector3.down * 0.25f, _disappearDuration * 2f))
                    .SetEase(Ease.InOutSine)
                ;
        }
    }
}