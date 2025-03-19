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
        private static IEntityBehaviourFactory ViewFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        public Entity<GameScope> Create(Vector2 position)
        {
            return ViewFactory.CreateShopView(position).Entity
                    .Add<DebugName, string>("Shop")
                    .Add<Shop>()
                    .Add<WorldPosition, Vector2>(position)
                ;
        }
    }
}