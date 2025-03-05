using DG.Tweening;
using UnityEngine;

namespace DeckScaler
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Transform _background;
        [SerializeField] private Transform _fill;
        [SerializeField] private float _updateValueDuration = 0.1f;

        private Tween _tween;

        public void DoNormalizedValue(float value)
        {
            _tween?.Kill();

            var bgScale = _background.localScale;
            var scale = _fill.localScale;
            scale.x = bgScale.x * value.Clamp();

            _tween = _fill.DOScale(scale, _updateValueDuration)
                .SetEase(Ease.InOutSine);
        }
    }
}