using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class UiVisibilityView : BaseListener<UiScope, Visible>
    {
        [SerializeField] private GameObject _target;

        public override void OnValueChanged(Entity<UiScope> entity, Visible component)
            => _target.SetActive(component.Value);
    }
}