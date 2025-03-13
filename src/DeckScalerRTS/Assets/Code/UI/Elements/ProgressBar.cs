using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private Gradient _fillGradient = DefaultGradient();
        [SerializeField] private TMP_Text _textMesh;
        [SerializeField] private bool _floorToInt = true;

        private float _value;
        private float _maxValue;

        public HpData HpData
        {
            set
            {
                var normalizedValue = value.NormalizedPercent;
                _fill.fillAmount = normalizedValue;
                _fill.color = _fillGradient.Evaluate(normalizedValue);

                if (_textMesh != null)
                    _textMesh.text = value.ToString();
            }
        }

        private static Gradient DefaultGradient()
        {
            var alpha = new[] { new GradientAlphaKey { alpha = 1f, time = 0f } };
            var color = new[] { new GradientColorKey { color = Color.green, time = 0f } };
            var gradient = new Gradient();
            gradient.SetKeys(color, alpha);

            return gradient;
        }
    }
}