using UnityEngine;

namespace DeckScaler
{
    public class SelectionAreaView : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;

        public void Show()
        {
            UpdatePositions(new(Vector2.zero, Vector2.zero));
            _target.gameObject.SetActive(true);
        }

        public void UpdatePositions(Rect rect)
        {
            var center = rect.center;
            _target.anchoredPosition = center;
            _target.sizeDelta = rect.size;
        }

        public void Hide()
        {
            _target.gameObject.SetActive(false);
        }
    }
}