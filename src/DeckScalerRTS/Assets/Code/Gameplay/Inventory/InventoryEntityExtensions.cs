using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public static class InventoryEntityExtensions
    {
        public static Sprite GetItemSpriteOrDefault(this Entity<GameScope> slot)
            => slot.GetOrDefault<ItemInSlot>()?.Value
                .GetEntity().Get<ItemSprite, Sprite>();
    }
}