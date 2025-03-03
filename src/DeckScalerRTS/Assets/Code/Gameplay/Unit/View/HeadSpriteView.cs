using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class HeadSpriteView : BaseListener<GameScope, HeadSprite>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<GameScope> entity, HeadSprite component)
            => _spriteRenderer.sprite = component.Value;
    }
}