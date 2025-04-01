using System;
using System.Linq;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class InventoryConfig
    {
        [field: SerializeField] private ItemConfig[]    Items    { get; set; }
        [field: SerializeField] public  EntityBehaviour ItemView { get; private set; }

        [field: SerializeField] public UiConfig UI { get; private set; }

        public ItemConfig GetItemConfig(ItemIDRef id) => Items.Single(c => c.ID == id);

        [Serializable]
        public class UiConfig
        {
            [field: SerializeField] public UiEntityBehaviour SlotViewPrefab { get; private set; }
            [field: SerializeField] public UiEntityBehaviour ItemViewPrefab { get; private set; }
        }
    }
}