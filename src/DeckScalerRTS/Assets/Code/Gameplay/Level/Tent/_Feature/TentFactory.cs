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
        private static IViewFactory ViewFactory => ServiceLocator.Resolve<IViewFactory>();

        private static LevelsConfig LevelConfig => ServiceLocator.Resolve<IGameConfig>().Levels;

        public Entity<GameScope> Create(Vector2 position)
            => ViewFactory.CreateInWorld(LevelConfig.TentView, position).Entity
                .Add<DebugName, string>("tent")
                .Is<Tent>(true)
                .Add<WorldPosition, Vector2>(position)
                .Is<OnEnemySide>(true)
                .Add<OnSide, Side>(Side.Enemy);
    }
}