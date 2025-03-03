using Pathfinding;
using UnityEngine;

namespace DeckScaler
{
    public interface IPathfindingService : IService
    {
        Path CalculatePath(Vector3 start, Vector3 end);
    }

    public class AStarPathfindingService : IPathfindingService
    {
        // ReSharper disable once NotAccessedField.Local TODO: do i need this at all??
        private readonly AstarPath _pathfinding;

        public AStarPathfindingService(AstarPath pathfinding)
        {
            _pathfinding = pathfinding;
        }

        public Path CalculatePath(Vector3 start, Vector3 end) => ABPath.Construct(start, end);
    }
}