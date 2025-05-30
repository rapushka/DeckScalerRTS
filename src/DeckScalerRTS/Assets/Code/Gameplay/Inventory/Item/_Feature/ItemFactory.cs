using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IItemFactory : IService
    {
        Entity<GameScope> CreateOnGround(ItemSpawnSetup setup);
    }

    public class ItemFactory : IItemFactory
    {
        private static InventoryConfig InventoryConfig => ServiceLocator.Resolve<IGameConfig>().Inventory;

        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        private static IInfluenceFactory InfluenceFactory => ServiceLocator.Resolve<IInfluenceFactory>();

        public Entity<GameScope> CreateOnGround(ItemSpawnSetup setup)
        {
            var itemID = setup.ID;
            var position = setup.SpawnPoint.position;

            var config = InventoryConfig.GetItemConfig(itemID);

            var item = ViewFactory.CreateInWorld(InventoryConfig.ItemView, position).Entity
                    .Add<DebugName, string>(TrimItemID(itemID))
                    .Add<ItemID, ItemIDRef>(itemID)
                    .Add<ItemSprite, Sprite>(config.Icon)
                    .Add<WorldPosition, Vector2>(position)
                    .Add<Clickable>()
                    .Add<LyingOnGround>()
                    .Add<Visible, bool>(true)
                    .Is<Drink>(config.IsDrink)
                    .Is<Trinket>(config.IsTrinket)
                ;

            if (config.IsDrink)
            {
                item
                    .Add<AffectOnUsed, AffectConfig>(config.DrinkAffect)
                    ;
            }

            if (config.IsTrinket)
            {
                foreach (var (statID, modifier) in config.TrinketModifiers.Modifiers)
                    InfluenceFactory.Create(item, statID, modifier);
            }

            return item;
        }

        private string TrimItemID(string source)
        {
#if UNITY_EDITOR
            source = source.Remove(Constants.TableID.Items);
#endif

            return source;
        }
    }
}