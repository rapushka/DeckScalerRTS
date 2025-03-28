using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class ScreenPositionView : BaseListener<UiScope, ScreenPosition>
    {
        [SerializeField] private RectTransform _target;

        public override void OnValueChanged(Entity<UiScope> entity, ScreenPosition component)
        {
            _target.position = component.Value;
        }
    }
}