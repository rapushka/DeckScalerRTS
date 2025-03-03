using System.Collections.Generic;
using DeckScaler.Scope;
using Entitas;
using Entitas.Generic;
using Pathfinding;
using UnityEngine;

namespace DeckScaler
{
    public sealed class CalculatePathToMoveOrderSystem : IExecuteSystem
    {
        private readonly IGroup<Entity<GameScope>> _entities
            = GroupBuilder<GameScope>
                .With<OrderMoveToPosition>()
                .And<WorldPosition>()
                .Build();

        private readonly List<Entity<GameScope>> _buffer = new(64);

        private static IPathfindingService Pathfinding => ServiceLocator.Resolve<IPathfindingService>();

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var entityPosition = entity.Get<WorldPosition, Vector2>();
                var targetPosition = entity.Get<OrderMoveToPosition, Vector2>();

                Debug.Log($"{entityPosition} -> {targetPosition}");
                var path = Pathfinding.CalculatePath(entityPosition, targetPosition);

                entity.Add<CurrentPath, Path>(path)
                    .Remove<OrderMoveToPosition>();

                Debug.Log("---");
                foreach (var graphNode in path.path)
                {
                    Debug.Log(graphNode.position);
                }

                Debug.Log("---");
            }
        }
    }
}