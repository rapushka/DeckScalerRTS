using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class SelectedUnitView : BaseFlagListener<GameScope, SelectedUnit>
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Color _defaultColor = Color.white;
        [SerializeField] private Color _selectedColor = Color.green;

        protected override void OnValueChanged(Entity<GameScope> entity)
        {
            var isSelected = entity.Is<SelectedUnit>();
            _sprite.color = isSelected ? _selectedColor : _defaultColor;
        }
    }
}