using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class OnEnemySideView : BaseFlagListener<GameScope, OnEnemySide>
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Color _onEnemySideColor = Color.red;
        [SerializeField] private Color _neutralColor = Color.white;

        protected override void OnValueChanged(Entity<GameScope> entity)
        {
            _sprite.color = entity.Is<OnEnemySide>() ? _onEnemySideColor : _neutralColor;
        }
    }
}