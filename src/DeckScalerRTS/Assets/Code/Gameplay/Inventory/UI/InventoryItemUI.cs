using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class InventoryItemUI : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private static InventoryConfig InventoryConfig => ServiceLocator.Resolve<IGameConfig>().Inventory;

        public void SetItem(Entity<GameScope> item)
        {
            var itemID = item.Get<ItemID, ItemIDRef>();

            var itemConfig = InventoryConfig.GetItemConfig(itemID);
            _image.sprite = itemConfig.Icon;
            _image.color = Color.white;
        }

        public void SetEmpty()
        {
            _image.sprite = null;
            _image.color = Color.clear;
        }
    }
}