using DeckScaler.Scope;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class WorldPosition : ValueComponent<Vector2>, IInScope<GameScope>, IEvent<Self> { }
}