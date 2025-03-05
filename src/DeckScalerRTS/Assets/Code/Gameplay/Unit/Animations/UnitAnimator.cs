using DG.Tweening;
using UnityEngine;

namespace DeckScaler
{
    public interface IEntityAnimator { }

    public interface IUnitAnimator : IEntityAnimator
    {
        void PlayAttack(Vector2 targetWorldPosition);
    }

    public sealed class UnitAnimator : MonoBehaviour, IUnitAnimator
    {
        [SerializeField] private Transform _headTransform;

        [Header("Attack Animation")]
        [Range(0f, 1f)]
        [SerializeField] private float _normalizedPunchDistance = 0.2f;
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private int _vibrato = 10;
        [Range(0f, 1f)]
        [SerializeField] private float _elasticity = 1f;
        [SerializeField] private Ease _ease = Ease.InOutBack;

        private Tween _tween;

        public void PlayAttack(Vector2 targetWorldPosition)
        {
            _tween?.Kill();

            var headWorldPosition = _headTransform.position.Truncate();
            var punchDirection = (targetWorldPosition - headWorldPosition).normalized;
            var punch = punchDirection * _normalizedPunchDistance;

            _tween = _headTransform.DOPunchPosition(punch, _duration, _vibrato, _elasticity)
                .SetEase(_ease);
        }
    }
}