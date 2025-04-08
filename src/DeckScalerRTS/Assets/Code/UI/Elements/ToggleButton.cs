using System;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class ToggleButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        [SerializeField] private Color _colorUnpressed = Color.white;
        [SerializeField] private Color _colorPressed = Color.grey;

        [SerializeField] private bool _isPressedOnInit;

        public event Action Clicked;

        public bool IsPressed { get; private set; }

        private void OnEnable()
        {
            IsPressed = _isPressedOnInit;
            UpdateView();

            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        private void OnClick()
        {
            IsPressed = !IsPressed;
            UpdateView();

            Clicked?.Invoke();
        }

        private void UpdateView()
        {
            _button.image.color = IsPressed ? _colorPressed : _colorUnpressed;
        }
    }
}