using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class TransparentOnNotRaycastTargetView : BaseListener<UiScope, RaycastTarget>
    {
        [SerializeField] private Image _image;
        [SerializeField] [Range(0f, 1f)] private float _interactableTransparency = 1f;
        [SerializeField] [Range(0f, 1f)] private float _notInteractableTransparency = 0.5f;

        public override void OnValueChanged(Entity<UiScope> entity, RaycastTarget component)
        {
            var isInteractable = component.Value;
            _image.SetAlpha(isInteractable ? _interactableTransparency : _notInteractableTransparency);
        }
    }
}