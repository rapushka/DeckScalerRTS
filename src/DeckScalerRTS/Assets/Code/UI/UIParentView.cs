using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UIParentView : BaseListener<UiScope, UiParent>
    {
        [SerializeField] private RectTransform _target;

        public override void OnValueChanged(Entity<UiScope> entity, UiParent component)
            => _target.SetupToParent(component.Value);
    }
}