using System;
using System.Linq;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class InventoryConfig
    {
        [field: SerializeField] private ItemConfig[] Items { get; set; }

        public ItemConfig GetItemConfig(ItemIDRef id) => Items.Single(c => c.ID == id);
    }
}