using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface IShopFactory : IService
    {
        Entity<GameScope> Create(Vector2 position);
    }

    public class ShopFactory : IShopFactory
    {
        public Entity<GameScope> Create(Vector2 position)
        {
            return CreateEntity.Empty()
                    .Add<DebugName, string>("Shop")
                    .Add<Shop>()
                    .Add<WorldPosition, Vector2>(position)
                ;
        }
    }
}