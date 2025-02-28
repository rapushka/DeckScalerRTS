using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class SpriteViewComponentBehaviour : BaseListener<GameScope, HeadSprite>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<GameScope> entity, HeadSprite component)
            => _spriteRenderer.sprite = component.Value;
    }
}