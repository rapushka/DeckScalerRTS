using System.Collections.Generic;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class RequestPathToTargetPositionForSeekersSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<PathSeeker>()
                .And<MoveToPosition>()
                .Without<GoingToPoint>()
                .Without<Path>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity
                    // .Add<RequestPathTo, Vector2>(entity.Get<MoveToPosition>().Value)
                    .Add<GoingToPoint, Vector2>(entity.Get<MoveToPosition>().Value)
                    .Remove<MoveToPosition>()
                    ;
            }
        }
    }
}