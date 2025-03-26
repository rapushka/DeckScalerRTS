using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class ItemSpriteUiView : BaseListener<UiScope, ItemSprite>
    {
        [SerializeField] private Image _image;

        public override void OnValueChanged(Entity<UiScope> entity, ItemSprite component)
        {
            var sprite = component.Value;

            _image.sprite = sprite;
            _image.color = sprite is not null ? Color.white : Color.clear;
        }
    }
}