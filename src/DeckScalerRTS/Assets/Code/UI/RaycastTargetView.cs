using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class RaycastTargetView : BaseListener<UiScope, RaycastTarget>
    {
        [SerializeField] private Image _image;

        public override void OnValueChanged(Entity<UiScope> entity, RaycastTarget component)
            => _image.raycastTarget = component.Value;
    }
}