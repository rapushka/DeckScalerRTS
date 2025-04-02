using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class UiHighlightView : BaseListener<UiScope, Highlight>
    {
        [SerializeField] private Image _target;
        [SerializeField] private Color _defaultColor = Color.white;
        [SerializeField] private Color _highlightColor = Color.yellow;

        public override void OnValueChanged(Entity<UiScope> entity, Highlight component)
            => _target.color = entity.Is<Highlight>() ? _highlightColor : _defaultColor;
    }
}