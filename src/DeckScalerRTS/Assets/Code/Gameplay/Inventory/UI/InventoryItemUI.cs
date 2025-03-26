using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DeckScaler
{
    public class InventoryItemUI : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private static InventoryConfig InventoryConfig => ServiceLocator.Resolve<IGameConfig>().Inventory;

        public void UpdateView(Entity<GameScope> slot)
        {
            var setup = slot.TryGet<ItemInSlot, EntityID>(out var itemInSlot)
                ? FromItem(itemInSlot.GetEntity())
                : ImageSetup.Empty();

            _image.sprite = setup.Sprite;
            _image.color = setup.Color;
        }

        private ImageSetup FromItem(Entity<GameScope> item)
        {
            var itemID = item.Get<ItemID, ItemIDRef>();
            var itemConfig = InventoryConfig.GetItemConfig(itemID);

            return ImageSetup.FromSprite(itemConfig.Icon);
        }

        private readonly ref struct ImageSetup
        {
            private ImageSetup(Sprite sprite, Color color)
            {
                Sprite = sprite;
                Color = color;
            }

            public Sprite Sprite { get; }
            public Color  Color  { get; }

            public static ImageSetup Empty() => new(null, Color.clear);

            public static ImageSetup FromSprite(Sprite sprite) => new(sprite, Color.white);
        }
    }
}