using System.Collections.Generic;
using Entitas.Generic;
using Pathfinding;
using UnityEngine;

namespace DeckScaler
{
    public sealed class Path : ValueComponent<Queue<Vector2>>, IInScope<GameScope> { }

    public sealed class PathSeeker : ValueComponent<Seeker>, IInScope<GameScope> { }

    public sealed class CalculatingPath : FlagComponent, IInScope<GameScope> { }
}