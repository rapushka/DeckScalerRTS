using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class AvailableSpriteView : BaseListener<GameScope, Available>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _availableColor = Color.white;
        [SerializeField] private Color _unavailableColor = Color.gray;

        public override void OnValueChanged(Entity<GameScope> entity, Available component)
            => _spriteRenderer.color = entity.Is<Available>() ? _availableColor : _unavailableColor;
    }
}