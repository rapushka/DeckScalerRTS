using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class SpriteColorView : BaseListener<GameScope, SpriteColor>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public override void OnValueChanged(Entity<GameScope> entity, SpriteColor component)
            => _spriteRenderer.color = component.Value;
    }
}