using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class ItemSpriteView : BaseListener<GameScope, ItemSprite>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<GameScope> entity, ItemSprite component)
            => _spriteRenderer.sprite = component.Value;
    }
}