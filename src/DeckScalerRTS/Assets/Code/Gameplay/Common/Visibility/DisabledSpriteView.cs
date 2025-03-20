using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class DisabledSpriteView : BaseListener<GameScope, Disabled>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _enabledColor = Color.white;
        [SerializeField] private Color _disabledColor = Color.gray;

        public override void OnValueChanged(Entity<GameScope> entity, Disabled component)
            => _spriteRenderer.color = entity.Is<Disabled>() ? _disabledColor : _enabledColor;
    }
}