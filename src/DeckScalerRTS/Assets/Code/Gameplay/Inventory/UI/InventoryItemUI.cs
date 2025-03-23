using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class InventoryItemUI : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private static InventoryConfig InventoryConfig => ServiceLocator.Resolve<IGameConfig>().Inventory;

        public void Initialize(ItemIDRef itemID)
        {
            var itemConfig = InventoryConfig.GetItemConfig(itemID);
            _image.sprite = itemConfig.Icon;
        }
    }
}