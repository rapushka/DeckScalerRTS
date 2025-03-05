using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public interface ITentFactory : IService
    {
        Entity<GameScope> Create(Vector2 position);
    }

    public class TentFactory : ITentFactory
    {
        private static IEntityBehaviourFactory ViewFactory => ServiceLocator.Resolve<IEntityBehaviourFactory>();

        public Entity<GameScope> Create(Vector2 position)
        {
            return ViewFactory.CreateTentView(position).Entity
                    .Add<DebugName, string>("base")
                    .Is<Tent>(true)
                    .Is<OnEnemySide>(true)
                ;
        }
    }
}