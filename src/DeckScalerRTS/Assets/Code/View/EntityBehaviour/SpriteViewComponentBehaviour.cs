using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class SpriteViewComponentBehaviour : BaseListener<Game, HeadSprite>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<Game> entity, HeadSprite component)
            => _spriteRenderer.sprite = component.Value;
    }
}