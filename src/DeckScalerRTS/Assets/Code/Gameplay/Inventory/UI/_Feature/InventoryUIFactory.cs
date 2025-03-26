using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IInventoryUIFactory : IService
    {
        Entity<UiScope> CreateSlotView(Entity<GameScope> slot);
    }

    public class InventoryUIFactory : IInventoryUIFactory
    {
        private static InventoryConfig.UiConfig Config => ServiceLocator.Resolve<IGameConfig>().Inventory.UI;

        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        private static InventoryUI InventoryView => HUD.SelectedUnitView.Inventory;

        private static GameplayHUDPage HUD => ServiceLocator.Resolve<IUiMediator>().GetPage<GameplayHUDPage>();

        public Entity<UiScope> CreateSlotView(Entity<GameScope> slot)
        {
            var sprite = slot.GetItemSpriteOrDefault();

            return ViewFactory.CreateInUI(Config.SlotViewPrefab, InventoryView.Root).Entity
                .Add<DebugName, string>("Inventory Slot UI")
                .Add<InventoryItemSlotUiView, EntityID>(slot.ID())
                .Add<ItemSprite, Sprite>(sprite);
        }
    }
}