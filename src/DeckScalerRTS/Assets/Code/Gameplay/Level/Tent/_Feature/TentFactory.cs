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
            => ViewFactory.CreateTentView(position).Entity
                .Add<DebugName, string>("tent")
                .Is<Tent>(true)
                .Add<WorldPosition, Vector2>(position)
                .Is<OnEnemySide>(true)
                .Add<OnSide, Side>(Side.Enemy);
    }
}