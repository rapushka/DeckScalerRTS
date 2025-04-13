using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class FindPathSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<GoingToPoint>()
                .And<PathSeeker>()
                .And<WorldPosition>()
                .Without<CalculatingPath>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var seeker = entity.Get<PathSeeker>().Value;

                entity.Add<CalculatingPath>();
                seeker.StartPath(
                    entity.Get<WorldPosition>().Value,
                    entity.Get<GoingToPoint>().Value,
                    (path) =>
                    {
                        if (!entity.Has<GoingToPoint>())
                            return;

                        var waypoints = new Queue<Vector2>(path.vectorPath.Skip(1).Select(v3 => v3.Truncate()));
                        entity
                            .Set<Path, Queue<Vector2>>(waypoints)
                            .RemoveSafely<CalculatingPath>()
                            ;
                    }
                );
            }
        }
    }
}