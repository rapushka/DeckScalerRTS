using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IItemFactory : IService
    {
        Entity<GameScope> Create(ItemSpawnSetup setup);
    }

    public class ItemFactory : IItemFactory
    {
        private static InventoryConfig InventoryConfig => ServiceLocator.Resolve<IGameConfig>().Inventory;

        public Entity<GameScope> Create(ItemSpawnSetup setup)
        {
            var itemID = setup.ID;
            var position = setup.SpawnPoint.position;

            var config = InventoryConfig.GetItemConfig(itemID);

            return CreateEntity.Empty()
                    .Add<DebugName, string>(TrimItemID(itemID))
                    .Add<ItemID, ItemIDRef>(itemID)
                    .Add<ItemSprite, Sprite>(config.Icon)
                    .Add<WorldPosition, Vector2>(position)
                ;
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