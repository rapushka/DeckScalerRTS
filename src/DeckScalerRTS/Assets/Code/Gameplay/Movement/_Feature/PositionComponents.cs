using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class WorldPosition : ValueComponent<Vector2>, IInScope<GameScope>, IEvent<Self> { }

    public sealed class MoveToPosition : ValueComponent<Vector2>, IInScope<GameScope> { }

    public sealed class MovementSpeed : ValueComponent<float>, IInScope<GameScope> { }
}