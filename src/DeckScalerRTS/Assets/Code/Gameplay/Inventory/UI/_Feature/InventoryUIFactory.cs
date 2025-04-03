using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IInventoryUIFactory : IService
    {
        Entity<UiScope> CreateSlotView(Entity<GameScope> slot);
        Entity<UiScope> CreateItemInSlot(Entity<GameScope> item, Entity<UiScope> slotView);
    }

    public class InventoryUIFactory : IInventoryUIFactory
    {
        private static InventoryConfig.UiConfig Config => ServiceLocator.Resolve<IGameConfig>().Inventory.UI;

        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        private static InventoryUI InventoryView => HUD.SelectedUnitView.Inventory;

        private static GameplayHUDPage HUD => ServiceLocator.Resolve<IUiMediator>().GetPage<GameplayHUDPage>();

        public Entity<UiScope> CreateSlotView(Entity<GameScope> slot)
        {
            var view = ViewFactory.CreateInUI(Config.SlotViewPrefab, InventoryView.Root).Entity
                .Add<DebugName, string>("Inventory Slot UI")
                .Add<InventoryPart>()
                .Add<UiOfInventorySlot, EntityID>(slot.ID());

            return view;
        }

        public Entity<UiScope> CreateItemInSlot(Entity<GameScope> item, Entity<UiScope> slotView)
        {
            var sprite = item.Get<ItemSprite>().Value;
            var itemID = item.ID();

            slotView.Add<ItemInSlot, EntityID>(itemID);
            var slotMonoBehaviour = slotView.Get<UiView>().Value;
            var parent = (RectTransform)slotMonoBehaviour.transform;
            var view = ViewFactory.CreateInUI(Config.ItemViewPrefab, parent);
            ((RectTransform)view.transform).Reset();

            return view.Entity
                    .Add<DebugName, string>("Item UI")
                    .Add<InventoryPart>()
                    .Add<UiOfItem, EntityID>(itemID)
                    .Add<ItemSprite, Sprite>(sprite)
                    .Add<Draggable>()
                    .Add<UiParent, RectTransform>(parent)
                    .Add<InitUiParent, RectTransform>(parent)
                    .Add<RaycastTarget, bool>(true)
                    .Add<UseComment, string>(string.Empty)
                    .Add<ValidUsage, bool>(true)
                ;
        }
    }
}