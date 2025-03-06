using UnityEngine;

namespace DeckScaler
{
    public class SelectionAreaView : MonoBehaviour
    {
        [SerializeField] private RectTransform _target;

        private Vector2 _start;

        public void Show(Vector2 start)
        {
            _start = start;

            UpdatePositions(start);
            _target.gameObject.SetActive(true);
        }

        public void UpdatePositions(Vector2 end)
        {
            var center = (_start + end) / 2;
            _target.anchoredPosition = center;

            _target.sizeDelta = new(
                x: (_start.x - end.x).Abs(),
                y: (_start.y - end.y).Abs()
            );
        }

        public void Hide()
        {
            _target.gameObject.SetActive(false);
        }
    }
}